<template>
  <div class="m-toast"
    :class="{ toastFail: true,
        toastSuccess: toastType == 1,
        toastWarning: toastType == 2,
        toastInfo: toastType == 3,
    }"
  >
    <div v-if="toastType == tosatStatus.OK" class="toast-icon .m-icon icon-40 icon-toast-success"></div>
    <div v-else-if="toastType == tosatStatus.WARNING" class="toast-icon .m-icon icon-40 icon-toast-warning"></div>
    <div v-else-if="toastType == tosatStatus.INFO" class="toast-icon .m-icon icon-40 icon-toast-info"></div>
    <div v-else class="toast-icon .m-icon icon-40 icon-toast-fail"></div>

    <div class="toast-title">{{ toastTitle }}</div>
    <div class="toast-content">{{ toastMsg }}</div>
  </div>
</template>

<script>
import { ResultStatus } from "./../../utils/enums/status";

export default {
  name: "MToast",

  props: ["toastType", "toastMsg"],
  data() {
    return {
        toastTitle: "",
        tosatStatus: ResultStatus,
    };
  },

  /**
   * Khi tao ra toast thi kiem tra xem loai toast can hien thi
   * Author: KhaiND (10/12/2022)
   */
  created() {
    if (this.toastType == 1) {
      this.toastTitle = "Thành công";
    } else if (this.toastType == 2) {
      this.toastTitle = "Cảnh báo";
    } else if (this.toastType == 3) {
      this.toastTitle = "Thông báo";
    } else {
      this.toastTitle = "Lỗi";
    }
  },
};
</script>

<style scoped>
    @import url(../../styles/component/toast.css);
.m-toast {
  display: grid !important;
}
</style>