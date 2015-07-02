function onButtonClickIsMozilla( event, arguments ) {

    var mainWindow = window,
        browser = mainWindow.navigator.appCodeName,
        isMozilla = function () {
            return browser === "Mozilla";
        }
        
    if ( isMozilla() ) {
        alert( "Yes" );
    } else {
        alert( "No" );
    }
}