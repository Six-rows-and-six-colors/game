<?php


	$con=mysqli_connect('localhost','root','root','unityaccess');
	if (mysqli_connect_errno())
	{
		echo "Connection Failed";
		exit();
	}
	$username = $_POST["username"];
	$password = $_POST["password"];
	
	$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";
	
	$namecheck = mysqli_query($con,$namecheckquery) or die("2:Name check query failed.");
	if (mysqli_num_rows($namecheck)>0)
	{
		echo "3:username already exists.";
		exit();
	}
	$salt="\$S\$rounds=5000\$"."steamedham".$username."\$";
	$hash=crypt($password, $salt);
	
	$insertuser="INSERT INTO players(username,hash,salt) VALUES ('" . $username . "','" . $hash . "','" . $salt . "');";
	
	
	mysqli_query($con, $insertuser) or die("4:Insert players failed");
	
	
	echo "0";
?>