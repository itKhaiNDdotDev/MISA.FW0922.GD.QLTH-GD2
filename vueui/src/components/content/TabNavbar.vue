<template>
    <div class="content__navtab">
        <div class="m-tab">Quy trình</div>
        <div class="m-tab">Danh sách khoản thu</div>
        <div class="m-tab">Phụ huynh đăng ký</div>
        <div class="m-tab">Đăng ký khoản thu</div>
        <div class="m-tab tab--focus">Danh sách miễn giảm</div>
        <div class="m-tab">Danh sách áp dụng chính sách giá</div>
    </div>
</template>

<script>
export default {
    name: "TabNavbar"
}
</script>

<style scoped>
@import url(../../styles/component/tab.css);

.content__navtab {
    display: flex;
}
</style>