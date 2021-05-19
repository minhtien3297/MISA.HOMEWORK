<template>
  <div id="table">
    <v-simple-table fixed-header height="calc(100vh - 175px)">
      <thead>
        <tr>
          <th class="text-center">STT</th>
          <th class="text-center">NGÀY GHI TĂNG</th>
          <th class="text-center">MÃ TÀI SẢN</th>
          <th class="text-left">TÊN TÀI SẢN</th>
          <th class="text-center">LOẠI TÀI SẢN</th>
          <th class="text-left">PHÒNG BAN</th>
          <th class="text-right">NGUYÊN GIÁ</th>
          <th class="text-center">CHỨC NĂNG</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="asset in assets" :key="asset.index">
          <td class="border-left text-center"></td>
          <td class="text-center">{{ asset.IncreaseDate | formatDate }}</td>
          <td class="text-center">{{ asset.AssetCode }}</td>
          <td class="text-left">{{ asset.AssetName }}</td>
          <td class="text-center">{{ asset.AssetTypeName }}</td>
          <td class="text-left">{{ asset.DepartmentName }}</td>
          <td class="text-right">{{ asset.OriginalPrice | formatMoney }}</td>
          <td>
            <div class="d-flex justify-center border-right align-center">
              <!-- icon bút -->
              <v-btn icon @click="openForm()"
                ><v-icon>mdi-pencil-outline</v-icon></v-btn
              >

              <!-- icon thùng rác-->
              <v-btn icon @click="deleteAsset(asset.AssetId)"
                ><img src="../../assets/trash.svg"
              /></v-btn>

              <!-- icon đồng hồ -->
              <v-btn icon><v-icon>mdi-history</v-icon></v-btn>
            </div>
          </td>
        </tr>
      </tbody>
    </v-simple-table>
  </div>
</template>

<script>
import { mapActions, mapMutations, mapState } from "vuex";

export default {
  data() {
    return {
      assetDomain: "",
    };
  },

  computed: {
    ...mapState(["assets"]),
  },

  filters: {
    /**
     * Chuyển đổi kiểu hiển thị tiền theo VND
     * @param {Int}
     * CreatedBy: DMTIEN (15/5/2021)
     */
    formatMoney(salary) {
      if (!salary) {
        return " Không có dữ liệu ";
      }
      var formatter = new Intl.NumberFormat("de-DE", {
        style: "currency",
        currency: "VND",
        minimumFractionDigits: 0,
      });
      return formatter.format(salary);
    },

    /**
     * Chuyển đổi kiểu hiển thị ngày tháng
     * @param {DateTime}
     * CreatedBy: DMTIEN (15/5/2021)
     */
    formatDate(date) {
      if (date) {
        var newDate = new Date(date);
        var dateString = newDate.getDate();
        var monthString = newDate.getMonth() + 1;
        var year = newDate.getFullYear();
        // Thêm số 0 nếu ngày nhỏ hơn 10
        if (dateString < 10) {
          dateString = "0" + dateString;
        }
        // Thêm số 0 nếu tháng nhỏ hơn 10
        if (monthString < 10) {
          monthString = "0" + monthString;
        }
        return `${dateString}/${monthString}/${year}`;
      } else {
        return " Không có dữ liệu ";
      }
    },
  },

  mounted() {
    this.resizeColumn();
  },

  methods: {
    // Mở form
    ...mapMutations(["openForm"]),

    //  xoá tài sản
    ...mapActions(["deleteAsset"]),

    /**
     * Điều chỉnh độ rộng của cột table
     * CreatedBy: DMTIEN (15/5/2021)
     */
    async resizeColumn() {
      var thElm;
      var startOffset;

      await Array.prototype.forEach.call(
        document.querySelectorAll("table td"),
        function (th) {
          th.style.position = "relative";

          var grip = document.createElement("div");
          grip.innerHTML = "&nbsp;";
          grip.style.top = 0;
          grip.style.right = 0;
          grip.style.bottom = 0;
          grip.style.width = "5px";
          grip.style.position = "absolute";
          grip.style.cursor = "col-resize";
          grip.addEventListener("mousedown", function (e) {
            thElm = th;
            startOffset = th.offsetWidth - e.pageX;
          });

          th.appendChild(grip);
        }
      );

      await document.addEventListener("mousemove", function (e) {
        if (thElm) {
          thElm.style.width = startOffset + e.pageX + "px";
        }
      });

      await document.addEventListener("mouseup", function () {
        thElm = undefined;
      });
    },
  },
};
</script>

<style>
#table {
  margin: 0px 27px 0px 21px;
}

/* tạo số thứ tự */
body {
  counter-reset: Serial; /* Thiết lập serial thành 0 */
}

table {
  border-collapse: separate;
}

tr td:first-child:before {
  counter-increment: Serial; /* tăng serial */
  content: counter(Serial); /* hiện serial */
}

/* border */
#table td {
  border: 1px solid lightgray;
}

/* xoá border bên trái */
.border-left {
  border-left: none !important;
}

/* Xoá border bên phải */
.border-right {
  border-right: none !important;
}

/* nền xanh cho dòng đầu tiên của table*/
tbody tr:first-child {
  background-color: #f0f8ff !important;
}

/* ẩn scrollbar của table */
#table .v-data-table__wrapper::-webkit-scrollbar {
  display: none;
}

/* màu của icon */
.v-icon {
  color: #8d8e9f !important;
}
</style>
