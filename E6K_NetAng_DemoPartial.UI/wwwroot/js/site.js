// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function OnCountryChange(input) {
//    console.log(input);
//    console.log(input.value);

//    let country = input.value;

//    if (country === '0') {
//        $('#villes').html('');
//        return;
//    }

//    console.log('call ajax');
//    $.ajax({
//        type: 'GET',
//        url: 'Sample/Villes/' + country,
//        success: function (r) {
//            $('#villes').html(r);
//        },
//        error: function (xhr, status, error) {
//            var err = eval("(" + xhr.responseText + ")");
//            console.log(err.Message);
//        }
//    });
//}

document.querySelector('select[name="Pays"]')?.addEventListener('change', async function () {
    const PaysID = this.value;
    const Ville = document.getElementById('Villes');
    if (PaysID === '0') {
        Ville.innerHTML = '';
        return;
    }
    
    const response = await fetch('/sample/villes/' + PaysID)
    Ville.innerHTML = await response.text();
})
