var cart = {
    init: function () {
        cart.regEvents();
    },

    regEvents: function(){
        $('#btnContinue').off('click').on('click', function (event) {
            event.preventDefault();
            window.location.href = "/san-pham/";
        });

       
    }




}

cart.init();