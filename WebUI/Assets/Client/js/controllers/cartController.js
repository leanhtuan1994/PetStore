var cart = {
    init: function () {
        cart.regEvents();
    },

    regEvents: function(){
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/san-pham/";
        });

       
    }




}

cart.init();