<?


 header("Access-Control-Allow-Origin: *");
    header("Content-Type: application/json;");
    header("Access-Control-Allow-Methods: POST");
    header("Access-Control-Max-Age: 3600");
    header("Access-Control-Allow-Headers: Content-Type, 
    Access-Control-Allow-Headers, Authorization, X-Requested-With");

include_once 'config/database.php';
 	 
$data = json_decode(file_get_contents("php://input"),true);
$arr = array_shift($data);

$arr["fio"]=htmlspecialchars(strip_tags($arr["fio"]));
$arr["tel"]=htmlspecialchars(strip_tags($arr["tel"]));
$arr["kto"]=htmlspecialchars(strip_tags( $arr["kto"]));

if ($arr["fio"]!="" &&  $arr["tel"] !="" &&  $arr["kto"]!=""){
	$query="UPDATE contacts
	SET fio ='".$arr["fio"]."' , tel = '".$arr["tel"]."', kto = '".$arr["kto"]."'
	WHERE id=".$arr["id"]."" ;
	$statement = $connect->prepare($query);
	$statement->execute();
}
?>