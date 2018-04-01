
// this dependency is curently expressied in index.html
// import $ from 'jquery'


let i = 0;

$( document ).ready(function() {
    console.log( "ready!" );
    // event handler for button-click
    $('#button1').click(function() {
        i++;
        this.textContent = "Danke vielmals! "+i;
    })
});

