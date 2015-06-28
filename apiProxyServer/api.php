<?php
apc_clear_cache();
header("Cache-Control: no-cache, must-revalidate");
header("Expires: Mon, 26 Jul 1997 05:00:00 GMT");
header("X-Developer-Version-No-Cache: true");
?><?php
$miasto = $_GET['miasto'];
$cel    = $_GET['cel'];

$yahooResponse = getYahooForecastResponse($miasto);
if ($yahooResponse->query->results==NULL) echo "city_error"; else
switch ($cel){
	case 'temperatura':
		echo (int)(($yahooResponse->query->results->channel->item->condition->temp -32)/1.8);
		break;
	case 'obrazek':
		$url = 'http://l.yimg.com/a/i/us/we/52/'.$yahooResponse->query->results->channel->item->condition->code.'.gif';
		header('Content-type: image/gif');
		echo file_get_contents($url);
		break;
	case 'dump':
		echo '<pre>';
		var_dump($yahooResponse);
		echo '</pre>';
		break;
	default:
		echo 'target_error';
}

function getYahooForecastResponse($city){
	$BASE_URL = "http://query.yahooapis.com/v1/public/yql";

    $yql_query = 'select * from weather.forecast where woeid in (select woeid from geo.places(1) where text="'.$city.', pl")';
    $yql_query_url = $BASE_URL . "?q=" . urlencode($yql_query) . "&format=json";

    // Make call with cURL
    $session = curl_init($yql_query_url);
    curl_setopt($session, CURLOPT_RETURNTRANSFER,true);
    $json = curl_exec($session);
    // Convert JSON to PHP object
    $phpObj =  json_decode($json);
    return $phpObj;
}

?>