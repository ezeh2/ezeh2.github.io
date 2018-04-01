
import $ from 'jquery'
import u from 'jquery-ui'

let i = 0;

$( document ).ready(function() {
    console.log( "ready!" );
// kommentar
    $('#button1').click(function() {
        i++;
        this.textContent = "Danke vielmals! "+i;
    })
});

