( function () {
    var canvas = document.getElementById( 'canvas' );
    var ctx = canvas.getContext( '2d' );
    var Ball,
        currentBall,
        CONSTANTS = {
            CANVAS_MIN_X: 0,
            CANVAS_MUN_Y: 0,
            CANVAS_MAX_X: canvas.width,
            CANVAS_MAX_Y: canvas.height,
        };

    ctx.strokeRect( CONSTANTS.CANVAS_MIN_X, CONSTANTS.CANVAS_MUN_Y, 
        CONSTANTS.CANVAS_MAX_X, CONSTANTS.CANVAS_MAX_Y );
        

    Ball = ( function () {
        var ballObject;        

        ballObject = ( function () {
            ballObject = Object.create( {} );

            Object.defineProperty( ballObject, 'init', {
                value: function ( x, y, color ) {
                    this._x = x;
                    this._y = y;
                    this._radius = 50;
                    this._color = color;
                    this._moveX = 4;
                    this._moveY = 4;

                    return this;
                }
            } );

            Object.defineProperty( ballObject, 'draw', {
                value: function () {                   
                    ctx.fillStyle = this._color;
                    ctx.beginPath();
                    ctx.arc( this._x, this._y, this._radius, 0, 2 * Math.PI );
                    ctx.closePath()
                    ctx.fill();

                    return this;
                }
            } );

            Object.defineProperty( ballObject, 'update', {
                value: function () {
                   
                    this._x += this._moveX;
                    this._y += this._moveY;

                    return this;
                }
            } );

            Object.defineProperty( ballObject, 'changeDirectionIfCollision', {
                value: function () {                    
                    var nextMinX = this._x - this._radius + this._moveX,
                    nextMaxX = this._x + this._radius + this._moveX,
                    nextMinY = this._y - this._radius + this._moveY,
                    nextMaxY = this._y + this._radius + this._moveY;
                                       
                    // change x
                    if ( nextMinX <= CONSTANTS.CANVAS_MIN_X || CONSTANTS.CANVAS_MAX_X <= nextMaxX ) {
                        this._moveX *= -1;
                    }

                    // change Y
                    if ( nextMinY <= CONSTANTS.CANVAS_MUN_Y || CONSTANTS.CANVAS_MAX_Y <= nextMaxY ) {
                        this._moveY *= -1;
                    }



                    return this;
                }
            } );

            return ballObject;
        }() );

        return {
            createBall: function (x, y, color) {
                return Object.create( ballObject ).init(x, y, color);
            }
        }
    }() );

    currentBall = Ball.createBall( 200, 200, 'orange' );
    
    function animateBall() {
        ctx.clearRect( 1, 1, canvas.width - 2, canvas.height - 2 );

        currentBall.changeDirectionIfCollision().update().draw();       

        requestAnimationFrame( animateBall );
    }
    
    return animateBall();
}() );