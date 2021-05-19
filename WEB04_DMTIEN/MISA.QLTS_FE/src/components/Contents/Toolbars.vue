<template>
  <div id="toolbar" class="d-flex">
    <!-- search input -->
    <v-text-field
      outlined
      class="rounded-0"
      placeholder="Tìm kiếm"
      append-icon="mdi-magnify"
    ></v-text-field>

    <!-- buttons -->
    <div class="buttons ml-auto d-flex">
      <!-- nút thêm -->
      <v-btn @click="openForm" class="big-buttons" depressed> Thêm </v-btn>

      <!-- nút tải lại -->
      <v-btn
        class="small-buttons"
        depressed
        fab
        tile
        x-small
        @click="getAssets"
        ><img src="../../assets/refresh.svg"
      /></v-btn>

      <!-- nút xoá -->
      <v-btn class="small-buttons" depressed fab tile x-small
        ><img src="../../assets/trash.svg"
      /></v-btn>
    </div>

    <!-- form -->
    <Form></Form>
  </div>
</template>

<script>
import Form from "./Form";
import { mapActions, mapMutations } from "vuex";

export default {
  components: {
    Form,
  },

  data() {
    return {};
  },

  methods: {
    // mở form
    ...mapMutations(["openForm"]),

    // Lấy dữ liệu tài sản
    ...mapActions(["getAssets"]),
  },
};
</script>

<style>
#toolbar {
  margin: 18px 21px 0px 21px;
  height: 55px;
}

/* search box */
#toolbar .v-input__slot {
  min-height: auto !important;
  display: flex !important;
  align-items: center !important;
  width: 422px;
  height: 35px;
}

/* search icon */
#toolbar .v-input__slot .v-input__append-inner {
  margin-top: 6px;
}

/* buttons */
#toolbar .buttons {
  width: 202px;
  margin-right: 33px;
}

#toolbar .buttons button {
  height: 35px;
  margin-right: 5px;
  margin-left: 5px;
  border-radius: 4px;
}

/* nút thêm */
#toolbar .buttons .big-buttons {
  background-color: #00abfe;
  color: #ffffff;
  width: 135px;
}

/* nút xoá và tải lại */
#toolbar .buttons .small-buttons {
  width: 35px;
  border: 1px solid #e0e0e0;
  background-color: #ffffff;
}
</style>
