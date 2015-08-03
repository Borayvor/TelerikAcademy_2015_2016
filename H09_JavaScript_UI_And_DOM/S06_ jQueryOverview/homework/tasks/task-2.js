/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/

/// <reference path="..\node_modules\jquery\dist\jquery.js" />
function solve() {
    return function ( selector ) {
        var $root;

        if ( typeof ( selector ) !== 'string' && !( selector instanceof HTMLElement ) ) {
            throw new Error();
        }

        $root = $( selector );

        if ( $root.length === 0 ) {
            throw new Error();
        }

        $root.find( '.button' ).each( function () {
            $( this ).text( 'hide' );
        } );

        $root.on( 'click', '.button', function () {
            var $button = $( this );

            var $content = $button.next( '.content' ),
                contentLength = $content.length;

            if ( contentLength !== 0 ) {
                if ( $content.css( 'display' ) === 'none' ) {
                    $button.text( 'hide' );
                    $content.css( 'display', '' );
                } else {
                    $button.text( 'show' );
                    $content.css( 'display', 'none' );
                }
            }
        } )
    };
};

module.exports = solve;

