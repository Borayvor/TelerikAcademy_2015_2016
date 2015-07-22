( function () {
    var canvas = document.getElementById( 'canvas' );
    var ctx = canvas.getContext( '2d' );
    var inputElement = document.getElementById( 'playerName' );

    var sn,
           apple,
           applePosition,
           msg;

    var snake,
        bodySection,
        isMoved = false,
        isAppleEaten = false,
        isPlayerScoreSave = false,
        isGameEnd = false,
        isGameStart = false,
        isSaveKeyOn = false,
        isPause = true,
        isGameOff = true,
        scoreInfo = [],
        currentScore,
        CONSTANTS = {
            OBJECT_SIZE: 20,
            HEAD_COLOR: 'black',
            BODY_COLOR: 'green',
            APPLE_COLOR: 'red',
            EMPTY_STRING: '',
        },
        dir,
        directions = {
            left: {
                x: -1,
                y: 0
            },
            right: {
                x: +1,
                y: 0
            },
            up: {
                x: 0,
                y: -1
            },
            down: {
                x: 0,
                y: +1
            },
        };

    document.onkeydown = function ( key ) {
        if ( key.keyCode === 37 && dir !== 'right' && isMoved ) {
            dir = 'left';
            isMoved = false;
        } else if ( key.keyCode === 38 && dir !== 'down' && isMoved ) {
            dir = 'up';
            isMoved = false;
        } else if ( key.keyCode === 39 && dir !== 'left' && isMoved ) {
            dir = 'right';
            isMoved = false;
        } else if ( key.keyCode === 40 && dir !== 'up' && isMoved ) {
            dir = 'down';
            isMoved = false;
        } else if ( key.keyCode === 13 && isGameEnd && !isPlayerScoreSave && isPause ) {
            isSaveKeyOn = true;
        } else if ( key.keyCode === 32 && isGameEnd && !isGameStart && isPlayerScoreSave ) {
            isGameOff = false;
            isPause = false;
            isGameStart = true;
            isGameEnd = false;
        }
    };

    bodySection = ( function () {
        var bodySection = Object.create( {} );

        Object.defineProperty( bodySection, 'init', {
            value: function ( x, y, size, color ) {
                this.x = x;
                this.y = y;
                this._size = size;
                this.color = color;

                return this;
            }
        } );

        Object.defineProperty( bodySection, 'x', {
            get: function () {
                return this._x;
            },
            set: function ( value ) {
                this._x = value;

                return this;
            }
        } );

        Object.defineProperty( bodySection, 'y', {
            get: function () {
                return this._y;
            },
            set: function ( value ) {
                this._y = value;

                return this;
            }
        } );

        Object.defineProperty( bodySection, 'size', {
            get: function () {
                return this._size;
            }
        } );

        Object.defineProperty( bodySection, 'color', {
            get: function () {
                return this._color;
            },
            set: function ( value ) {
                this._color = value;

                return this;
            }
        } );

        return bodySection;
    }() );

    snake = ( function () {
        var snake = Object.create( [] );
        var bodyStartLength = 4;

        Object.defineProperty( snake, 'init', {
            value: function ( x, y ) {
                var i,
                    len = bodyStartLength;

                this.push( Object.create( bodySection ).init( x, y,
                    CONSTANTS.OBJECT_SIZE, CONSTANTS.HEAD_COLOR ) );

                for ( i = 0; i < len; i += 1 ) {
                    this.push( Object.create( bodySection )
                        .init( x - ( ( i + 1 ) * CONSTANTS.OBJECT_SIZE ), y,
                        CONSTANTS.OBJECT_SIZE, CONSTANTS.BODY_COLOR ) );
                }

                return this;
            }
        } );


        Object.defineProperty( snake, 'addBodySection', {
            value: function ( direction ) {
                var currentSnakeLength = this.length;

                this.unshift( Object.create( bodySection )
                        .init( this[0].x + ( this[0].size * direction.x ),
                        this[0].y + ( this[0].size * direction.y ), this[0].size,
                        this[0].color ) );

                this[1].color = CONSTANTS.BODY_COLOR;

                return this;
            }
        } );

        Object.defineProperty( snake, 'move', {
            value: function ( direction ) {

                var thisSize = this[0].size;

                var xPos = this[0].x + ( thisSize * direction.x );
                var yPos = this[0].y + ( thisSize * direction.y );

                this.pop();

                this.unshift( Object.create( bodySection )
                        .init( xPos, yPos, this[0].size, this[0].color ) );

                this[1].color = CONSTANTS.BODY_COLOR;

                return this;
            }
        } );

        return snake;
    }() );

    function draw() {
        var obj,
            i,
            len,
            objIndex,
            objLen = arguments.length || 1;

        ctx.clearRect( 1, 1, canvas.width - 2, canvas.height - 2 );

        ctx.save();

        for ( objIndex = 0; objIndex < objLen; objIndex += 1 ) {
            obj = arguments[objIndex];
            len = obj.length;

            if ( len !== undefined ) {
                for ( i = 0; i < len; i += 1 ) {
                    ctx.fillStyle = obj[i].color;
                    ctx.fillRect( obj[i].x, obj[i].y, obj[i].size, obj[i].size );
                    ctx.strokeRect( obj[i].x, obj[i].y, obj[i].size, obj[i].size );
                }
            } else {
                ctx.fillStyle = obj.color;
                ctx.fillRect( obj.x, obj.y, obj.size, obj.size );
                ctx.strokeRect( obj.x, obj.y, obj.size, obj.size );
            }
        }

        ctx.save();
        ctx.fillStyle = 'purple';
        ctx.font = '20px Arial';
        ctx.fillText( 'Score ' + currentScore, 20, 30 );
        ctx.restore();

        ctx.restore();
    }

    function checkForCollision( sn, apple ) {
        var i,
            len = sn.length;

        if ( sn[0].x === apple.x && sn[0].y === apple.y ) {
            applePosition = getRandomPosition();
            apple.init( applePosition.x, applePosition.y,
                CONSTANTS.OBJECT_SIZE, CONSTANTS.APPLE_COLOR );

            isAppleEaten = true;
        }

        if ( sn[0].x < 0 || canvas.width < ( sn[0].x + sn[0].size ) ) {
            isGameStart = false;
            isGameEnd = true;
            isPause = true;
            msg = 'You are Death !';
        }

        if ( sn[0].y < 0 || canvas.height < ( sn[0].y + sn[0].size ) ) {
            isGameStart = false;
            isGameEnd = true;
            isPause = true;
            msg = 'You are Death !';
        }

        for ( i = 1; i < len; i += 1 ) {
            if ( sn[0].x === sn[i].x && sn[0].y === sn[i].y ) {
                isGameStart = false;
                isGameEnd = true;
                isPause = true
                msg = 'You are Cannibal !';
            }
        }
    }

    function getRandomIntInclusive( min, max ) {
        return Math.floor( Math.random() * ( max - min + 1 ) ) + min;
    }

    function getRandomPosition() {
        var x = getRandomIntInclusive( 0,
            Math.round(( canvas.width - 2 - CONSTANTS.OBJECT_SIZE )
            / CONSTANTS.OBJECT_SIZE ) )
            * CONSTANTS.OBJECT_SIZE;

        var y = getRandomIntInclusive( 0,
            Math.round(( canvas.height - 2 - CONSTANTS.OBJECT_SIZE )
            / CONSTANTS.OBJECT_SIZE ) )
            * CONSTANTS.OBJECT_SIZE;

        return {
            x: x,
            y: y
        };
    }

    function updateSnake() {
        if ( isAppleEaten ) {
            sn.addBodySection( directions[dir] );
            isAppleEaten = false;
            currentScore += 1;
        } else {
            sn.move( directions[dir] );
        }
    }

    function update() {
        checkForCollision( sn, apple );
        updateSnake( sn );
        draw( sn, apple );
        isMoved = true;
    }

    function drawInitGameField() {
        ctx.save();
        ctx.clearRect( 0, 0, canvas.width, canvas.height );
        ctx.strokeStyle = 'red';
        ctx.strokeRect( 0, 0, canvas.width, canvas.height );
        ctx.restore();
    }

    function finalMessage() {
        ctx.save();
        ctx.fillStyle = 'purple';
        ctx.font = '62px Arial';
        ctx.fillText( msg, 150, 200 );
        ctx.fillText( 'Game Over !', 180, 270 );
        ctx.fillText( 'Please enter your name !', 70, 340 );
        if ( isSaveKeyOn ) {
            ctx.fillText( 'Press spacebar for', 120, 430 );
            ctx.fillText( 'new game !', 180, 500 );
        }
        ctx.restore();
    }

    function savePlayerScore() {
        var playerName,
            ul,
            li;

        if ( !isGameStart && isGameEnd && !isPlayerScoreSave ) {
            inputElement.disabled = false;
            inputElement.focus();

            if ( isSaveKeyOn ) {
                playerName = inputElement.value;
                scoreInfo[playerName] = currentScore;

                ul = document.getElementById( 'scoreList' );

                li = document.createElement( 'li' );
                li.innerHTML = playerName + ' - ' + ( scoreInfo[playerName] );
                ul.appendChild( li );

                isPlayerScoreSave = true;
                inputElement.value = CONSTANTS.EMPTY_STRING;
                inputElement.disabled = true;
            }
        }
    }

    function animate() {

        var play = setInterval( function () {

            if ( !isGameOff ) {
                newGame();
            }

            if ( isPause && !isGameStart && isGameEnd ) {
                draw( sn, apple );
                finalMessage();
            } else {
                update( sn, apple );
            }

            savePlayerScore();

        }, 110 );
    }

    function newGame() {

        dir = 'right';
        currentScore = 0;
        isSaveKeyOn = false;
        isPlayerScoreSave = false;
        isGameOff = true;

        inputElement.value = CONSTANTS.EMPTY_STRING;
        inputElement.disabled = true;

        drawInitGameField();

        sn = Object.create( snake ).init( 100, 100 );

        applePosition = getRandomPosition();
        apple = Object.create( bodySection ).init( applePosition.x, applePosition.y,
            CONSTANTS.OBJECT_SIZE, CONSTANTS.APPLE_COLOR );

        draw( sn, apple );
    }

    function snakeGame() {
        newGame();

        animate();
    }

    return snakeGame();
}() );