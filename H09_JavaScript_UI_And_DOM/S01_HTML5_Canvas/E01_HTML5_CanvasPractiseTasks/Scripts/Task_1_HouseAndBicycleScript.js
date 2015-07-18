( function () {
    function drawHouseAndBicycle() {

        var canvas = document.getElementById( 'canvas' );
        var canvasCtx = canvas.getContext( '2d' );

        drawFace( canvasCtx );
        drawBicycle( canvasCtx );
        drawHouse( canvasCtx );

    }

    function ellipse( ctx, x, y, radius, startPointDegree, endPointDegree, scaleX, scaleY ) {

        var start = startPointDegree * Math.PI / 180;
        var end = endPointDegree * Math.PI / 180;

        ctx.save();
        ctx.scale( scaleX, scaleY );
        ctx.arc( x / scaleX, y / scaleY, radius, start, end );
        ctx.restore();
    }

    function drawFace( ctx ) {
        var angleToRotateMouth;

        ctx.save();
        ctx.fillStyle = 'rgb(107, 187, 201)';
        ctx.strokeStyle = 'rgb(2, 55, 155)';

        ctx.beginPath();
        ctx.arc( 200, 250, 70, 0, 2 * Math.PI );
        ctx.fill();
        ctx.stroke();

        // eyes
        ctx.fillStyle = 'rgb(2, 55, 155)';
        ctx.beginPath();
        ellipse( ctx, 155, 225, 10, 0, 360, 1, 0.6 );
        ctx.stroke();
        ctx.beginPath();
        ellipse( ctx, 217, 225, 10, 0, 360, 1, 0.6 );
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 152, 225, 6, 0, 360, 0.6, 1 );
        ctx.fill();
        ctx.beginPath();
        ellipse( ctx, 214, 225, 6, 0, 360, 0.6, 1 );
        ctx.fill();

        //nose
        ctx.beginPath();
        ctx.moveTo( 186, 225 );
        ctx.lineTo( 170, 265 );
        ctx.lineTo( 186, 265 );
        ctx.stroke();

        //mouth
        ctx.save();
        angleToRotateMouth = 10 * Math.PI / 180;
        ctx.translate( 185, 290 );
        ctx.beginPath();        
        ctx.rotate( angleToRotateMouth );
        ellipse( ctx, 0, 0, 18, 0, 360, 1.6, 0.4 );        
        ctx.stroke();
        ctx.restore();

        //hat
        ctx.strokeStyle = 'rgb(0, 0, 0)';
        ctx.fillStyle = 'rgb(2, 55, 155)';
        ctx.beginPath();
        ellipse( ctx, 190, 190, 80, 0, 360, 1, 0.2 );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 200, 190, 40, 0, 360, 1, 0.2 );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 160, 190 );
        ctx.lineTo( 160, 90 );
        ctx.lineTo( 240, 90 );
        ctx.lineTo( 240, 190 );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 200, 90, 40, 0, 360, 1, 0.2 );
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawBicycle( ctx ) {

        ctx.save();
        ctx.fillStyle = 'rgb(255, 255, 255)';
        ctx.strokeStyle = 'rgb(2, 55, 155)';
        ctx.beginPath();
        ctx.moveTo( 197, 455 );
        ctx.lineTo( 233, 505 );
        ctx.stroke();

        ctx.beginPath();
        ctx.arc( 215, 480, 15, 0, 2 * Math.PI );
        ctx.fill();
        ctx.stroke();
        ctx.restore();

        ctx.save();
        ctx.fillStyle = 'rgb(107, 187, 201)';
        ctx.strokeStyle = 'rgb(2, 55, 155)';

        //left circle
        ctx.beginPath();
        ctx.arc( 120, 480, 60, 0, 2 * Math.PI );
        ctx.fill();
        ctx.stroke();

        //right circle
        ctx.beginPath();
        ctx.arc( 330, 480, 60, 0, 2 * Math.PI );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 215, 480 );
        ctx.lineTo( 120, 480 );
        ctx.lineTo( 190, 410 );
        ctx.lineTo( 320, 410 );
        ctx.lineTo( 215, 480 );
        ctx.lineTo( 182, 390 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 170, 390 );
        ctx.lineTo( 195, 390 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 330, 480 );
        ctx.lineTo( 316, 380 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 316, 380 );
        ctx.lineTo( 285, 390 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 316, 380 );
        ctx.lineTo( 343, 360 );
        ctx.stroke();

        ctx.restore();
    }

    function drawHouse( ctx ) {
        ctx.save();
        ctx.fillStyle = 'rgb(151, 91, 91)';
        ctx.strokeStyle = 'rgb(0, 0, 0)';
        ctx.beginPath();
        ctx.moveTo( 550, 210 );
        ctx.lineTo( 550, 470 );
        ctx.lineTo( 810, 470 );
        ctx.lineTo( 810, 210 );
        ctx.lineTo( 680, 60 );
        ctx.lineTo( 550, 210 );
        ctx.lineTo( 810, 210 );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 736, 180 );
        ctx.lineTo( 736, 90 );
        ctx.lineTo( 760, 90 );
        ctx.lineTo( 760, 180 );
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 748, 90, 12, 0, 360, 1, 0.2 );
        ctx.fill();
        ctx.stroke();

        ctx.save();
        ctx.fillStyle = 'rgb(0, 0, 0)';
        ctx.fillRect( 570, 230, 40, 30 );
        ctx.fillRect( 615, 230, 40, 30 );
        ctx.fillRect( 570, 265, 40, 30 );
        ctx.fillRect( 615, 265, 40, 30 );

        ctx.fillRect( 700, 230, 40, 30 );
        ctx.fillRect( 745, 230, 40, 30 );
        ctx.fillRect( 700, 265, 40, 30 );
        ctx.fillRect( 745, 265, 40, 30 );

        ctx.fillRect( 700, 350, 40, 30 );
        ctx.fillRect( 745, 350, 40, 30 );
        ctx.fillRect( 700, 385, 40, 30 );
        ctx.fillRect( 745, 385, 40, 30 );
        ctx.restore();

        ctx.beginPath();
        ctx.moveTo( 580, 470 );
        ctx.lineTo( 580, 370 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 610, 470 );
        ctx.lineTo( 610, 355 );
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo( 640, 470 );
        ctx.lineTo( 640, 370 );
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 610, 370, 30, 180, 0, 1, 0.5 );
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 600, 420, 5, 0, 360, 1, 1 );
        ctx.stroke();

        ctx.beginPath();
        ellipse( ctx, 620, 420, 5, 0, 360, 1, 1 );
        ctx.stroke();

        ctx.restore();
    }

    return drawHouseAndBicycle();
}() );