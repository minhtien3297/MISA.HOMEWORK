<template>
  <div id="form">
    <v-dialog v-model="dialog" persistent max-width="985px">
      <!-- form -->
      <v-card tile>
        <!-- title -->
        <v-card-title>
          <span class="headline font-weight-bold">Ghi tăng tài sản</span>

          <!-- nút đóng -->
          <div class="ml-auto d-flex">
            <!-- nút trợ giúp -->
            <v-btn icon class="mr-3"><img src="../../assets/help.svg" /></v-btn>

            <!-- nút đóng form -->
            <v-btn icon @click="closeForm"
              ><img src="../../assets/cancel.svg"
            /></v-btn>
          </div>
        </v-card-title>

        <!-- imputs -->
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="4">
                <!-- Mã tài sản -->
                <v-container>
                  <label>Mã tài sản (*)</label
                  ><v-select
                    outlined
                    dense
                    class="rounded-0"
                    :items="this.$store.state.assets"
                    item-text="AssetId"
                    item-value="AssetName"
                    @click="getName(AssetId + '')"
                  >
                  </v-select
                ></v-container>
              </v-col>

              <v-col cols="8">
                <!-- Tên tài sản -->
                <v-container
                  ><label>Tên tài sản (*)</label>
                  <v-text-field
                    outlined
                    dense
                    disabled
                    filled
                    class="rounded-0"
                  >
                  </v-text-field
                ></v-container>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="4">
                <!-- Mã phòng ban -->
                <v-container>
                  <label>Mã phòng ban</label>
                  <v-select outlined dense class="rounded-0"></v-select>
                </v-container>
              </v-col>

              <v-col cols="8">
                <!-- Tên phòng ban -->
                <v-container
                  ><label>Tên phòng ban</label>
                  <v-text-field
                    outlined
                    dense
                    disabled
                    filled
                    class="rounded-0"
                  >
                  </v-text-field
                ></v-container>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="4">
                <!-- Mã loại tài sản -->
                <v-container>
                  <label>Mã loại tài sản</label>
                  <v-select outlined dense class="rounded-0"></v-select>
                </v-container>
              </v-col>

              <v-col cols="8">
                <!-- Tên loại tài sản -->
                <v-container
                  ><label>Tên loại tài sản</label>
                  <v-text-field
                    outlined
                    dense
                    disabled
                    filled
                    class="rounded-0"
                  >
                  </v-text-field
                ></v-container>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="4">
                <!-- Ngày ghi tăng-->
                <v-container>
                  <label>Ngày ghi tăng</label>
                  <v-text-field outlined dense class="rounded-0" type="date">
                    <!-- icon lịch -->
                    <template v-slot:append>
                      <v-fade-transition leave-absolute>
                        <img
                          width="24"
                          height="24"
                          src="../../assets/calendar-60.svg"
                          alt=""
                      /></v-fade-transition> </template
                  ></v-text-field>
                </v-container>
              </v-col>

              <v-col cols="4">
                <!-- Thời gian sử dụng -->
                <v-container>
                  <label>Thời gian sử dụng (năm)</label>
                  <v-text-field outlined dense class="rounded-0"></v-text-field>
                </v-container>
              </v-col>

              <v-col cols="4">
                <!-- Tỷ lệ hao mòn -->
                <v-container>
                  <label>Tỷ lệ hao mòn (%)</label>
                  <v-text-field outlined dense class="rounded-0"></v-text-field>
                </v-container>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="4">
                <!-- Nguyên giá -->
                <v-container>
                  <label>Nguyên giá</label>
                  <v-text-field outlined dense class="rounded-0"></v-text-field>
                </v-container>
              </v-col>

              <v-col cols="4">
                <!-- Giá trị hao mòn năm -->
                <v-container>
                  <label>Giá trị hao mòn năm</label>
                  <v-text-field dense outlined class="rounded-0"></v-text-field>
                </v-container>
              </v-col>

              <v-col cols="4"></v-col>
            </v-row>
          </v-container>
        </v-card-text>

        <!-- buttons -->
        <v-card-actions>
          <!-- nút hủy -->
          <v-btn @click="closeForm"> Hủy </v-btn>

          <!-- nút lưu -->
          <v-btn class="btnSave ml-auto" depressed @click="closeForm">
            Lưu
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapState, mapMutations } from "vuex";
import axios from "axios";

export default {
  data: () => ({
    ids: [],
  }),

  computed: mapState({
    dialog: (state) => state.dialog,
  }),

  methods: {
    ...mapMutations(["closeForm"]),
    getId() {
      const me = this;
      this.$store.state.assets.forEach((asset) => {
        me.ids.push(asset.AssetId);
      });
    },
    getName(id) {
      try {
        const sqlCommand = `Select a.AssetName FROM Asset a WHERE AssetId = '${id}'`;

        axios
          .get("https://localhost:44349/api/v1/Assets/text?text=" + sqlCommand)
          .then((res) => console.log(res));
      } catch (ex) {
        ex;
      }
    },
  },
  async mounted() {
    await this.$store.dispatch("getAssets");
    this.getId();
  },
};
</script>

<style>
.v-dialog {
  height: 643px;
}

/* kích thước của form */
.v-card {
  height: 643px;
}

.v-card .v-card__title {
  height: 75px;
}

.v-card .container {
  margin-left: 0px;
  max-width: 978px;
}

.v-card .col {
  padding-top: 0px;
  padding-bottom: 0px;
}
.v-card .v-card__text {
  height: 510px;
  padding: 0px !important;
}

.v-card__text .container {
  padding-top: 0px;
  padding-bottom: 0px;
}

/*  kích thước nút trợ giúp và đóng form */
.v-card .v-card__title .v-btn img {
  height: 22px;
}

/* màu viền input */
.v-card .v-card__text .v-text-field--outlined fieldset {
  border: 1px solid #e6e6e6 !important;
}

/* Ẩn icon lịch mặc định */
#form input[type="date"]::-webkit-inner-spin-button,
input[type="date"]::-webkit-calendar-picker-indicator {
  display: none;
  -webkit-appearance: none;
}

/* màu nền của phần buttons */
.v-card__actions {
  background-color: #f5f5f5;
  height: 70px;
}

.v-card__actions .v-btn {
  border: 1px solid #bdbdbd;
  width: 135px;
}

/* nút lưu */
.v-card__actions .btnSave {
  background-color: #00abfe !important;
  color: #ffffff;
  border: none;
}
</style>
