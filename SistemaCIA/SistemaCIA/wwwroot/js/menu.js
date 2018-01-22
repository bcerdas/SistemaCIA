$(document).ready(function(){
 
	$(window).scroll(function(){
		if( $(this).scrollTop() > 500 ){
			$('nav').addClass('navbar-fixed-top');
		} else {
			$('nav').removeClass('navbar-fixed-top');
		}
	});
 
});