$(document).ready(function () {

    $('.element').mousedown(function (event) {
        //todo: remove right-click default function (menu) possibly with: event.preventDefault();

        var arr = this.id.split('_');

        var x = arr[1];
        var y = arr[2];

        switch (event.which) {
            case 1:
                window.location.replace("Index.aspx?x=" + x + "&y=" + y + "&click=left");
                break;
            case 3:
                window.location.replace("Index.aspx?x=" + x + "&y=" + y + "&click=right");
                break;
            default:
                alert('You have a strange Mouse!');
                break;
        }

    });
})

