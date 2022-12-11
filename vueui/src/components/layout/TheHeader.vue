<template>
    <div class="header">
        <div class="header--left header-title">Lập kế hoạch thu</div>

        <div class="header--right">
            <div class="m-input nav-home-app">
                <div class="m-icon icon-home"></div>
                [Thí điểm] Trường tiểu học Edu Platform 4
            </div>
            <m-dropdown value="2021 - 2022" style="width: 124px"></m-dropdown>
            <div class="m-button text-button btn-guide">Hướng dẫn</div>
           
            <div class="hor-line"></div>
            <div class="m-icon icon-32 icon-help-green" title="Thông báo"></div>
            <div class="m-icon icon-32 icon-notification" title="Thông báo">
                <div class="noti--quantity">9+</div>
            </div>

            <div class="m-account">
                <img src="../../assets/Images/KhaiND.png" alt="ảnh đại diện" class="acc-avatar">
                <div class="acc-name">KhaiND</div>
                <div class="m-icon icon-24 icon-down" title="Quản lý tài khoản"></div>
            </div>          
        </div>
    </div>
</template>

<script>
// import MInput from "./../base/MInput.vue";
import MDropdown from "./../base/MDropdown.vue";

export default {
  name: "TheHeader",
  components: {
    // MInput,
    MDropdown
  }
};
</script>

<style>
@import url(../../styles/layout/header.css);

.btn-guide {
    background-color: #00925340;
    color: var(--main-green);
    margin: 0px !important;
}

.nav-home-app {
    width: fit-content;
    display: flex;
    align-items: center;
    margin: 0px 16px;
    padding-left: 0px !important;
}

.nav-home-app .icon-home {
    background-color: var(--main-green);
    width: 30px;
    height: 30px;
    margin-right: 12px;
    border-radius: 4px 0px 0px 4px;
}
</style>