$(document).ready(function () {
  showForm();
  hideForm()
});

/**
 *  Hiển thị form insert
 * CreatedBy: DMTIEN (15/4/2021)
 */
function showForm() {
    //Hiện form khi ấn vào nút thêm
    $('#button-insert').click(function(){
        $("#insert-form").removeClass("insert-form-hide");
    })
}

/**
 * Ẩn form insert
 * CreatedBy: DMTIEN (15/4/2021)
 */
function hideForm() {
  // Ẩn form khi ấn vào nút thoát
  $("#clsButton").click(function () {
    $("#insert-form").addClass("insert-form-hide");
  });
}
