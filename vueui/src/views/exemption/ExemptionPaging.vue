<template>
    <div class="content__paging">
        <div class="paging--left">
            <span>Tổng số&nbsp;</span>
            <span class="paging__number">17</span>
            <span>&nbsp;danh sách miễn giảm</span>
        </div>
        <div class="paging--right">
            <span>Trang &nbsp;</span>
            <div class="page-index">
                <input type="text" class="m-input">
                <div class="page--up">&#xe64d;</div>
                <div class="page--down">&#xe64e;</div>
            </div>
            <span>&nbsp; trên tổng số&nbsp;</span>
            <span class="paging__number">1</span>
            <span>&nbsp;trang</span>
        </div>
    </div>
</template>

<script>
// import MInput from "./../../components/base/MInput.vue";

export default {
    name: "ExemptionPaging",
    components: {
        // MInput
    }
}
</script>

<style>
    .paging--left, .paging--right {
        display: flex;
        align-items: center;
    }

    .paging__number {
        font-family: OpenSansBold;
    }

    .page-index {
        width: 96px;
        margin: 0px;
        position: relative;
    }
    .page-index input {
        width: 100%;
        padding-right: 24px;
    }
    .page-index .page--up, .page-index .page--down {
        font-family: IconFont;
        position: absolute;
        right: 1px;
        width: 15px;
        height: 15px;
        color: green;
        background-color: lightcoral;
        cursor: pointer;
    }
    .page-index .page--up {
        top: 1px;
    }
    .page-index .page--down {
        bottom: 1px;
    }
</style>