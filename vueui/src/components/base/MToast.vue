<template>
  <div class="m-toast"
    :class="{ toastFail: true,
        toastSuccess: toastType == toastStatus.OK,
        toastWarning: toastType == toastStatus.WARNING,
        toastInfo: toastType == toastStatus.INFO,
    }"
  >
    <div v-if="toastType == toastStatus.OK" class="toast-icon .m-icon icon-40 icon-toast-success"></div>
    <div v-else-if="toastType == toastStatus.WARNING" class="toast-icon .m-icon icon-40 icon-toast-warning"></div>
    <div v-else-if="toastType == toastStatus.INFO" class="toast-icon .m-icon icon-40 icon-toast-info"></div>
    <div v-else class="toast-icon .m-icon icon-40 icon-toast-fail"></div>

    <div class="toast-title">{{ toastTitle }}</div>
    <div class="toast-content">{{ toastMsg }}</div>
  </div>
</template>

<script>
import { ResultStatus } from "./../../utils/enums/status";
import Resources from "./../../utils/resources/common"

export default {
  name: "MToast",

  props: ["toastType", "toastMsg"],
  data() {
    return {
        toastTitle: "",
        toastStatus: ResultStatus,
    };
  },

  /**
   * Khi khởi tạo toast message thì kiểm tra loại trạng thái toast để hiện thị title tương ứng
   * Author: KhaiND (10/12/2022)
   */
  created() {
    if (this.toastType == this.toastStatus.OK) {
      this.toastTitle = Resources.ToastTitle.Success;
    }
    else if (this.toastType == this.toastStatus.WARNING) {
      this.toastTitle = Resources.ToastTitle.Warning;
    }
    else if (this.toastType == this.toastStatus.INFO) {
      this.toastTitle = Resources.ToastTitle.Info;
    }
    else {
      this.toastTitle = Resources.ToastTitle.Error;
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