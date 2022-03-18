$(document).ready(function () {

  // people
  $("#people").click(function () {
    $.get("/Ajax/People", function (data, response) {
      if (response == "success")
        $("#content").html(data);
    }).catch(function () {
      $("#content").html("<div class=\"row\">No persons to display.</div>");
    });
  });

  // details
  $("#details").click(function () {
    $.post("/Ajax/Details", { id: $("#id").val() }, function (data, response) {
      if (response == "success")
        $("#content").html(data);
    }).catch(function () {
      $("#content").html("<div class=\"row p-2\">Could not find person with that id.</div>");;
    });
  });

  // delete
  $("#delete").click(function () {
    let id = $("#id").val();
    $.post("/Ajax/Delete", { id: $("#id").val() }, function (data, response) {
      if (response == "success")
        $("#content").html("<div class=\"row p-2\">Person deleted.</div>");
    }).catch(function () {
      $("#content").html("<div class=\"row p-2\">Could not delete person with that id.</div>");
    });
  });

});