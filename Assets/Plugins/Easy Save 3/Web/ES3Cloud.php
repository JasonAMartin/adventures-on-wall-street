<?php
/* 
------------------------------------------------------------------------------------
			IT IS NOT NECESSARY TO MODIFY THIS SCRIPT TO USE EASY SAVE 3 CLOUD
------------------------------------------------------------------------------------
*/
	
	
$tableName 			= 	"es3cloud";		// The name of the table used to store file names.
$filenameField 		= 	"filename";		// The name of the field where we save our file name.
$fileDataField 		= 	"data";			// The name of the field containing the data relating to.
$userField	  		=	"user";			// The name of the field containing the name of the user this file relates to, if any.
$lastUpdatedField 	= 	"lastUpdated"; 	// The name of the field containing the last updated timestamp.
	
// Handles installation of the database tables and variables script.
if(!file_exists("ES3Variables.php"))
{
	if(!isset($_POST["dbHost"]))
		PreInstall();
	else
		Install($_POST["dbHost"], $_POST["dbUser"], $_POST["dbPassword"], $_POST["dbName"], $tableName, $filenameField, $fileDataField, $userField, $lastUpdatedField);
	exit();
}

include_once "ES3Variables.php";

if($_POST["apiKey"] != $api_key)
	Error("Incorrect API Key", "Incorrect API Key", 403);

// Check connection to database.
try
{
	$db = new PDO("mysql:host=$db_host;dbname=$db_name", $db_user, $db_password, array(PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION));
}
catch(PDOException $e)
{
	Error("Could not connect to database.", $e->getMessage(), 501);
}

// ----- GET FILE -----
if(isset($_POST["getFile"]))
{
	$stmt = $db->prepare("SELECT $fileDataField FROM $tableName WHERE $filenameField = :filename AND $userField = :user AND $lastUpdatedField > :timestamp LIMIT 1");
	$stmt->bindParam(":filename", $_POST["getFile"]);
	$stmt->bindParam(":user", GetPOSTUser());
	$stmt->bindParam(":timestamp", GetPOSTTimestamp());
	$stmt->execute();
	if($stmt->rowCount() > 0)
	{
		$data = $stmt->fetchColumn();
		// Manually set the content length so WWW.progress works.
		header($_SERVER["SERVER_PROTOCOL"] . " 200 OK");
		header("Cache-Control: public");
		header("Content-Type: application/octet-stream");
		header("Content-Transfer-Encoding: Binary");
		header("Content-Length:".strlen($data));
		echo $data;
	}
}

// ----- PUT FILE -----
else if(isset($_POST["putFile"]))
{
	// Get uploaded data.
	$filePath = $_FILES["data"]["tmp_name"];
	
	// If file doesn't exist or it contains no data, throw an error.
	if(!file_exists($filePath) || filesize($filePath) == 0)
		Error("Uploaded file does not exist or is empty.", "Uploaded file does not exist or is empty.", 400);
	
	$fp = fopen($filePath, 'rb');
	
	$stmt = $db->prepare("INSERT INTO $tableName ($filenameField, $fileDataField, $userField, $lastUpdatedField) VALUES (:filename, :data, :user, :timestamp) ON DUPLICATE KEY UPDATE $fileDataField = VALUES($fileDataField), $lastUpdatedField = VALUES($lastUpdatedField)");
	$stmt->bindParam(":filename", $_POST["putFile"]);
	$stmt->bindParam(":data", $fp, PDO::PARAM_LOB);
	$stmt->bindParam(":user", GetPOSTUser());
	$stmt->bindParam(":timestamp", GetPOSTTimestamp());

	$stmt->execute();
}

// ----- DELETE FILE -----
else if(isset($_POST["deleteFile"]))
{
	$stmt = $db->prepare("DELETE FROM $tableName WHERE $filenameField = :filename AND $userField = :user");
	$stmt->bindParam(":filename", $_POST["deleteFile"]);
	$stmt->bindParam(":user", GetPOSTUser());
	$stmt->execute();
}

// ----- GET FILENAMES -----
else if(isset($_POST["getFilenames"]))
{
	$stmt = $db->prepare("SELECT GROUP_CONCAT($filenameField SEPARATOR ';') FROM $tableName WHERE $userField = :user");
	$stmt->bindParam(":user", GetPOSTUser());
	$stmt->execute();
	if($stmt->rowCount() > 0)
		echo $stmt->fetchColumn();
}

// ----- GET TIMESTAMP -----
else if(isset($_POST["getTimestamp"]))
{
	$stmt = $db->prepare("SELECT $lastUpdatedField FROM $tableName WHERE $filenameField = :filename AND $userField = :user LIMIT 1");
	$stmt->bindParam(":filename", $_POST["getTimestamp"]);
	$stmt->bindParam(":user", GetPOSTUser());
	$stmt->execute();
	if($stmt->rowCount() > 0)
		echo $stmt->fetchColumn();
	else
		Error("Could not get timestamp as file does not exist.", "Could not get timestamp as file does not exist.", 400);
}

else
	Error("No valid operation was specified", "No valid operation was specified", 400);
	
// Close the connection to the database by nullifying the variable.
$db = null;

function GetPOSTUser()
{
	return isset($_POST["user"]) ? $_POST["user"] : "";
}

function GetPOSTTimestamp()
{
	return isset($_POST["timestamp"]) ? $_POST["timestamp"] : 0;
}

function Error($headerMsg, $msg, $code)
{
	header($headerMsg, true, $code);
	print_r($msg);
	if(isset($GLOBALS['db']))
		$GLOBALS['db'] = null;
	exit();
}

// ------- INSTALL METHODS -------

function PreInstall()
{
	echo '	<div style="font-family:Arial, Helvetica, sans-serif">
			<h1>ES3 Cloud Installation</h1>
			<p>This will install the ES3 Cloud tables on your MySQL database, and add the required <em>ES3Variables.php</em> file to your server.</p>
			<p><strong>Please enter your database details below:</strong></p>
			<p>
				<form method="post">
					Database Host:<br>
					<input type="text" name="dbHost">
					<br>
					<br>
					Database User:<br>
					<input type="text" name="dbUser">
					<br>
					<br>
					Database Password:<br>
					<input type="password" name="dbPassword">
					<br>
					<br>
					Database Name:<br>
					<input type="text" name="dbName">
					<br>
					<br>
					<button type="submit" style="font-size:14pt; font-weight:bold;">Install ES3Cloud</button>
				</form>
			</p>
			</div>';
}

function Install($dbHost, $dbUser, $dbPassword, $dbName, $tableName, $filenameField, $fileDataField, $userField, $lastUpdatedField)
{
	try
	{
		$db = new PDO("mysql:host=$dbHost;dbname=$dbName", $dbUser, $dbPassword, array(PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION, PDO::ATTR_TIMEOUT => 5));
		
		$tableExists = $db->query("SELECT * FROM information_schema.tables WHERE table_schema = '$dbName' AND table_name = '$tableName' LIMIT 1;");
		if($tableExists->rowCount() == 0)
		{
				
			// Create the table if it doesn't already exist.
			try 
			{
					$createTableQuery = 
"CREATE TABLE IF NOT EXISTS `$tableName` (
`$filenameField` varchar(200) NOT NULL,
`$fileDataField` longblob NOT NULL,
`$userField` varchar(64) NOT NULL,
`$lastUpdatedField` int(11) unsigned NOT NULL DEFAULT '0',
PRIMARY KEY (`$filenameField`,`$userField`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;";
	        		$db->query($createTableQuery);
	    	} 
	    	catch (PDOException $e) 
	    	{
	        	echo "	<p>Could not create tables on database. Database threw error:</p><p>".$e->getMessage()."</p>
						<p>To manually install the MySQL tables, please run the following SQL code on your database:</p>
						<pre>$createTableQuery</pre>";
	        	exit();
	    	}
	    }
    	
    	try
    	{
	    	$apiKey = substr(md5(microtime()),rand(0,26),12);
	    	$phpScript =
"<?php
\$api_key		=	'$apiKey';		// The API key you need to specify to use when accessing this API.

\$db_host		= 	'$dbHost';		// MySQL Host Name.
\$db_user		= 	'$dbUser';		// MySQL User Name.
\$db_password		= 	'$dbPassword';	// MySQL Password.
\$db_name		= 	'$dbName';		// MySQL Database Name.
?>";
	    	
	    	file_put_contents("ES3Variables.php", $phpScript);
    	}
    	catch(Exception $e)
    	{
	    	echo "	<p>Couldn't create PHP file on your server. Server returned the following error:</p><p>".$e->getMessage()."</p>
	    			<p>To manually install the PHP file, please create a file named <em>ES3Variables.php</em> in the same directory as your ES3.php file with the following contents:</p>
					<pre>$phpScript</pre>
					<p>After creating this file, installation will be complete.</p>";
	    	exit();
    	}
    	
    	echo 
    	"
    		<div style='font-family:Arial, Helvetica, sans-serif'>
    		<h1>Successfully installed ES3Cloud</h1>
			<p><strong>IMPORTANT:</strong><br>Please take note of your API key below. You will need to use it whenever using the API.</p>
			<p>Your API key can also be found in the <em>ES3Variables.php</em> file which has just been installed.</p>
			<p style='font-size:16pt'><strong>API Key:</strong> $apiKey</p>
			</div>
    	";
	}
	catch(PDOException $e)
	{
		echo "<p><b>Database could not be accessed with these details</b>. The database returned the following error:</p><p>" . $e->getMessage() . "</p>";
		PreInstall();
		exit();
	}
}
	
?>