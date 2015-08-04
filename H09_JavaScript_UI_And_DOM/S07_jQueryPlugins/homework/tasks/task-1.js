/// <reference path="..\node_modules\jquery\dist\jquery.js" />

function solve() {
    return function ( selector ) {
        var $root = $( selector );
        var $currentElement = $root.find( 'option' );
        var $divWrapper = $( '<div />' ).addClass( 'dropdown-list' );
        var $divCurrentOption = $( '<div />' ).addClass( 'current' );

        $divWrapper.append( $divCurrentOption );

        var $divOptionsList = $( '<div />' ).addClass( 'options-container' )
            .hide().css( 'position', 'absolute' );

        $currentElement.each( function ( target, element ) {
            var $nextElement = $( element );

            target === $root.get( 0 ).selectedIndex
            && $divCurrentOption.html( $nextElement.html() ).attr( 'data-value', $nextElement.val() );

            $( '<div />' ).addClass( 'dropdown-item' ).html( $nextElement.html() )
                .attr( 'data-value', $nextElement.val() ).attr( 'data-index', target ).appendTo( $divOptionsList );
        } );

        $divWrapper.append( $divOptionsList );
        $root.before( $divWrapper );
        $divWrapper.prepend( $root );

        $divWrapper.on( 'click', '.current', function () {
            $divOptionsList.css( 'display' ) === 'none' ? ( $divOptionsList.show(),
                            $divCurrentOption.html( 'Select a value' ) ) : $divOptionsList.hide()
        } );

        $divWrapper.on( 'click', '.dropdown-item', function () {
            var $dropDownElement = $( this );

            $divCurrentOption.html( $dropDownElement.html() ).attr( 'data-value', $dropDownElement.val() ),
            $root.val( $dropDownElement.attr( 'data-value' ) ),
            $divOptionsList.hide()
        } );
        
        $root.hide();
    };
}

//module.exports = solve;