function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
		
		// you are welcome :)
        var $this = this;
		var date = new Date();

        $calendar = $('<div>').addClass('datepicker-wrapper');
        
        $this.addClass('datepicker').wrap($calendar);

        $calendar = $this.parent();

        var picker = $('<div />').addClass('picker');
        var controls = $('<div />').addClass('controls').appendTo(picker);
        var currentDateDiv = $('<div />').addClass('current-date').appendTo(picker);
    };
}