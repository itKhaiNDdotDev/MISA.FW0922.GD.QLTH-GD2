<template>
  <div class="m-popup-wrapper">
    <div class="m-dialog">
      <div class="dialog__header">{{dialogTitle.Notice}}</div>
      <div class="dialog__content">{{ dialogMsg }}</div>
      <div class="dialog__footer">
        <div class="m-button text-button btn-light" v-if="haveBtnClose" @click="onClose">{{buttonText.Close}}</div>
        <div class="m-button text-button btn-green" @click="onConfirm">{{buttonText.Confirm}}</div>
      </div>
      <div :title="tooltip.Close" class="m-icon icon-24 icon-close" @click="onClose"></div>
    </div>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";

export default {
  name: "MDialog",
  props: ["dialogMsg", "haveBtnClose"],

  data() {
    return {
      dialogTitle: Resources.DialogTitle,
      buttonText: Resources.Button,
      tooltip: Resources.ToolTip
    }
  },

  methods: {
    /**
     * Khi có sự kiện yêu cầu Đóng thì gọi đến component cha để ẩn đi và hủy DOM của Dialog tương ứng
     * Author: KhaiND (14/12/2022)
     */
    onClose() {
      this.$emit("onClose");
    },

    /**
     * Sự kiện khi người dùng bấm Đồng ý thì thực hiện action tương ứng được component cha yêu cầu
     * Author: KhaiND (26/12/2022)
     */
    onConfirm() {
      this.$emit("onConfirm");
    }
  },
};
</script>

<style>
@import url(../../styles/layout/popup.css);
@import url(../../styles/component/dialog.css);
</style>