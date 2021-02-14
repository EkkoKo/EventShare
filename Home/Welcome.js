var button = document.getElementById("buttonText");
var working = false;
button.onmouseover = function (e) {
  document.body.style.backgroundColor = "lightgrey";
 
};
button.onmouseout = function (e) {
  document.body.style.backgroundColor = "white";
};


var canvas4 = document.getElementById( "CircleAnimation" );

var $canvas = $('#CircleAnimation'),
    $window = $(window);

$canvas.attr({
    width: $window.width(),
    height: ($window.height() / 3),
});

var c4 = canvas4.getContext( '2d' );

// The Circle class
function Circle( x, y, dx, dy, radius ) {

	this.x 	= x;
	this.y 	= y;
	this.dx = dx;
	this.dy = dy;

	this.radius = radius;

	this.draw = function() {

		c4.beginPath();

		c4.arc( this.x, this.y,  this.radius, 0, Math.PI * 2, false  );

		c4.strokeStyle = "black";
			
		c4.stroke();
	}

	this.update = function() {

		if( this.x + this.radius > canvas4.width || this.x - this.radius < 0 ) {

			this.dx = -this.dx;
		}

		if( this.y + this.radius > canvas4.height || this.y - this.radius < 0 ) {

			this.dy = -this.dy;
		}

		this.x += this.dx;
		this.y += this.dy;

		this.draw();
	}
}

var circles = [];

// Radius
var radius = 50;

for( var i = 0; i < 20; i++ )  {
	
	// Starting Position
	var x = Math.random() * ( canvas4.width - radius * 2 ) + radius;
	var y = Math.random() * ( canvas4.height - radius * 2) + radius;

	// Speed in x and y direction
  	var dx = ( Math.random() - 0.5 ) * 2;
  	var dy = ( Math.random() - 0.5 ) * 2;

	circles.push( new Circle( x, y, dx, dy, radius ) );
}

function animate4() {
  
	requestAnimationFrame( animate4 );

	c4.clearRect( 0, 0, canvas4.width, canvas4.height );

	for( var r = 0; r < 20; r++ ) {

		circles[ r ].update();
	}
}

animate4();
