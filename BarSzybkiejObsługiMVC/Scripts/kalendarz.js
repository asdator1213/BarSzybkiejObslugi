$(function () {

    var terminDocelowy = '';

    $("#anuluj").click(function () {
        $("#termin").text(terminDocelowy);
        $("#przyblizony-czas").removeClass("hidden");
        $("#datetimepicker").addClass("hidden");
        $(this).addClass("hidden");
        $("#zmiana-terminu-odbioru").removeClass("hidden");
    });

    $("#zmiana-terminu-odbioru").click(function () {

        $(this).addClass("hidden");
        terminDocelowy = $("#termin").text();
        '@Model.NaKiedy';

        $("#datetimepicker").css({
            "display": "block",
            'margin': '20px auto'
        }).removeClass("hidden");

        $("#anuluj").removeClass("hidden");
        $("#przyblizony-czas").addClass("hidden");

        $("#datetimepicker").datetimepicker({
            startDate: '@Model.NaKiedy',
            minDate: '@DateTime.Now',
        });

        $("#datetimepicker").change(function () {
            var termin = $("#datetimepicker").val();
            console.log(termin);
            $("#termin").text(termin);
        });

    });
});