// Write your Javascript code.

$(document).ready(function(){
	console.log("WE'ere here");
	$('#btn').click(function () {
		console.log("WE'ere here");
		$.get("/random/code", function(result){
			console.log(result, "==this is the the result");
			$('#lblCode').html(result)
		})
	});
});
