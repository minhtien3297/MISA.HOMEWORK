/**
 * Khi nhấn vào combobox thì đóng/mở combobox
 * CreatedBy: DMTIEN (27/4/2021)
 */
selectedOption.addEventListener("click", function (element) {
  element.stopPropagation();
  closeSelect(this);
  this.nextElementSibling.classList.toggle("select-hide");
  this.classList.toggle("select-active");
});

/**
 * Hiện option tương ứng khi nhập vào input
 * CreatedBy: DMTIEN (27/4/2021)
 */
selectedOption.addEventListener("keyup", function (e) {
  var select = this.parentNode.getElementsByTagName("select")[0];
  var option = this.nextSibling.childNodes;

  for (var j = 0; j < select.length; j++) {
    // bỏ qua cảnh báo về option rỗng đầu tiên
    if (option[j] == undefined) {
      continue;
    }
    var isEqual =
      option[j].innerHTML
        .toLowerCase()
        .indexOf(selectedOption.value.toLowerCase()) == -1;
    if (isEqual) {
      // không trùng thì ẩn option
      option[j].setAttribute("style", "display:none");
    } else {
      // hiện option khi trùng
      option[j].removeAttribute("style");
    }
  }

  checkError(option, selectedOption, select);
});

/**
 * Đóng select
 * @param {div} element
 * CreatedBy: DMTIEN (27/4/2021)
 */
function closeSelect(element) {
  var listOption = document.getElementsByClassName("select-items");
  var opSelected = document.getElementsByClassName("select-selected");

  // Bỏ khung xanh khi nhấn bên ngoài
  if (element != opSelected[0]) {
    opSelected[0].classList.remove("select-active");
  }

  // Ẩn các option khi nhấn
  listOption[0].classList.add("select-hide");
}

/**
 * Đóng combobox sau khi nhấn vào bên ngoài combobox
 * CreatedBy: DMTIEN (27/4/2021)
 */
document.addEventListener("click", closeSelect);

/**
 * Bắt sự kiện nhấn lên xuống và enter
 * CreatedBy: DMTIEN (27/4/2021)
 */
// window.addEventListener("keyup", function (e) {
//   var select = document.getElementsByTagName("select")[0];
//   var option = select.childNodes.getElementsByTagName("div")[0];
//   var sldOption = select.childNodes.getElementById("sldOption");

//     // key up
//     if (e.keyCode == 38) {
//       if(select.indexOf(option) == 0){
//         select.indexOf(option) = select.length -1;
//       }
//       else{
//         select.indexOf(option)--;
//       }
//     }
//     // key down
//     else if (e.keyCode == 40) {
//       if(option == select.length - 1){
//         select.indexOf(option) = 0;
//       }
//       else{
//         select.indexOf(option)++;
//       }
//     }
// });

/**
 * Kiểm tra nếu nhập sai thì tô đỏ viền và hiện thông báo lỗi
 * CreatedBy: DMTIEN (27/4/2021)
 */
function checkError(option, selectedOption, select) {
  var countError = 0;

  for (var k = 0; k < select.length; k++) {
    // bỏ qua cảnh báo về option rỗng đầu tiên
    if (option[k] == undefined) {
      continue;
    }

    if (option[k].hasAttribute("style")) {
      countError++;
    }
  }

  // Kiểm tra nếu không có giá trị nào trùng thì báo lỗi, không thì thôi
  if (countError == 3) {
    selectedOption.classList.add("select-error");
    selectedOption.setAttribute(
      "title",
      "Dữ liệu không tồn tại trong hệ thống"
    );
  } else {
    selectedOption.classList.remove("select-error");
  }
}

function getValue(){
  var selected = document.getElementsByTagName("input")[0];
  var select = document.getElementsByTagName("select")[0];
  var option = document.getElementsByTagName("div");

  for(var i=0; i< select.length;i++)
  {
    if(selected.value == option[i])
    return selected.value;
  }
}
