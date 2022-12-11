<template>
  <div class="m-popup-wrapper">
    <div class="m-dialog">
      <div class="dialog__header">Thông báo</div>
      <div class="dialog__content">{{ dialogMsg }}</div>
      <div class="dialog__footer">
        <div @click="onClickClose" class="m-button text-button btn-light">Đóng</div>
        <div class="m-button text-button btn-green">Đồng ý</div>
      </div>
      <div title="Đóng" class="m-icon icon-24 icon-close" @click="onClickClose"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MDialog",
  props: ["dialogMsg"],

  methods: {},
};
</script>

<style>
@import url(../../styles/layout/popup.css);
@import url(../../styles/component/dialog.css);
</style>