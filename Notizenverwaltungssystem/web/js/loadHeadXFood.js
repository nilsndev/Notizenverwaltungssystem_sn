
        loadPage('../../header','header')
        loadPage('../../footer','footer')
        function loadPage(pageName,controlName){
            var xhr = new XMLHttpRequest();
            xhr.open('GET',pageName, true);
            xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                document.getElementById(controlName).innerHTML = xhr.responseText;
            }
        };
    xhr.send();
        }