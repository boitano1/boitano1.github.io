var x = 200;
var y = 400;

function setup() {
	createCanvas(1000, 1000);
}

function draw() {
	if (mouseIsPressed==true) {
		background(10, 113, 200);
		strokeWeight(32);
		for (i = 16; i <= 1000; i += 72) {
		stroke(10, 72, 231);
		line(i, 0, i, 1000);
		}
		
		for (i = 47; i <= 1000; i += 72) {
		stroke(10, 255, 35);
		line(i, 0, i, 1000);
		}
		noStroke();
		fill(231, 42, 10, 100);
		ellipse(245, 350, y, y);
		ellipse(700, 650, x, x);
		rect(580, 100, 500, 100);
	} else {
		
		
	background(245, 142, 55);
	strokeWeight(32);
	for (i = 16; i <= 1000; i += 72) {
	stroke(245, 183, 24);
	line(i, 0, i, 1000);
	}
	
	for (i = 47; i <= 1000; i += 72) {
	stroke(245, 0, 220);
	line(i, 0, i, 1000);
	}
	
	noStroke();
	fill(10, 255, 35, 100);
	ellipse(245, 350, y, y);
	ellipse(700, 650, x, x);
	rect(580, 100, 500, 100);

	}	
}