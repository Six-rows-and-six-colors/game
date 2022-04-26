<?php	
	$con=mysqli_connect('localhost','root','root','unityaccess');
	if (mysqli_connect_errno())
	{
		echo "1:Connection Failed";
		exit();
	}
	
	$username=$_POST["username"];
	$score=$_POST["score"];
	
	$namecheckquery="SELECT username,score FROM players WHERE username= '" . $username . "';";
	
	$namecheck=mysqli_query($con,$namecheckquery) or die("2:Name check query failed.");
	
	if(mysqli_num_rows($namecheck)!=1)
	{
		echo"5:Either no user with name, or more than one.";
		exit();
	}
	$updatequery= "UPDATE players SET score=" .$score . " WHERE username='" . $username . "';";
	mysqli_query($con,$updatequery) or die("7:Save query failed");
	
	echo "0";
	

?>