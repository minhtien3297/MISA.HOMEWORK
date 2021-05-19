// Tìm element có class là ComboBox
var combobox = document.getElementsByClassName("ComboBox");

// Tìm element có tag là select
var slElement = combobox[0].getElementsByTagName("select")[0];

// tạo div mới với vai trò là option được chọn
var selectedOption = document.createElement("INPUT");

selectedOption.setAttribute("class", "select-selected");
selectedOption.setAttribute("id", "sldOption");
selectedOption.setAttribute("placeholder", "Giới tính");
selectedOption.setAttribute("value", "");
selectedOption.setAttribute("autocomplete", "off");
combobox[0].appendChild(selectedOption);

// Tạo div mới để chứa danh sách option
var listOption = document.createElement("DIV");
listOption.setAttribute("class", "select-items select-hide");

// Tạo các div thay thế các option mặc định
for (var i = 1; i < slElement.length; i++) {
  var option = document.createElement("DIV");
  option.innerHTML = slElement.options[i].innerHTML;

  /**
   * Khi một option được chọn thì sẽ thay đổi select box ban đầu và option được chọn
   * CreatedBy: DMTIEN (26/4/2021)
   */
  option.addEventListener("click", function (element) {
    //  select sau khi đã chọn một option
    var slSelected = this.parentNode.parentNode.getElementsByTagName(
      "select"
    )[0];

    // Gán giá trị của option được chọn cho input
    document.getElementById("sldOption").value = element.target.innerHTML;

    for (var j = 0; j < slSelected.length; j++) {
      // Tô đậm option được chọn
      var opNotSelected = this.parentNode.getElementsByClassName(
        "highlight-selected"
      );
      for (var k = 0; k < opNotSelected.length; k++) {
        opNotSelected[k].removeAttribute("class");
      }
      this.setAttribute("class", "highlight-selected");
      break;
    }
  });

  // Thêm các option vào danh sách option
  listOption.appendChild(option);
}

// Thêm danh sách các option vào select
combobox[0].appendChild(listOption);
