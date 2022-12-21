<template>
    <div class="content__paging">
        <div class="paging--left">
            <span>{{pagingText.Total}}&nbsp;</span>
            <span class="paging__number">{{totalRecord}}</span>
            <span>&nbsp;{{pagingText.List.toLowerCase()}}</span>
        </div>
        <div class="paging--right">
            <span>{{pagingText.Page}} &nbsp;</span>
            <div class="page-index">
                <input type="text" class="m-input">
                <div class="page--up m-icon icon-up-next"></div>
                <div class="page--down m-icon icon-down-prev"></div>
            </div>
            <span>&nbsp; {{pagingText.onTotalPage.toLowerCase()}}&nbsp;</span>
            <span class="paging__number">{{totalPage}}</span>
            <span>&nbsp;{{pagingText.Page.toLowerCase()}}</span>
        </div>
    </div>
</template>

<script>
import ExemptionResources from "./../../utils/resources/exemption"
// import MInput from "./../../components/base/MInput.vue";

export default {
    name: "ExemptionPaging",
    components: {
        // MInput
    },

    data() {
        return {
            pagingText: ExemptionResources.Paging,
            totalRecord: 17,
            totalPage: 1
        }
    },
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
        width: 16px;
        height: 15px;
        cursor: pointer;
        border-radius: 4px;
    }
    .page-index .page--up {
        top: 1px;
    }
    .page-index .page--down {
        bottom: 1px;
    }
    .page-index .page--up:hover, .page-index .page--down:hover,
    .page-index .page--up:active, .page-index .page--down:active,
    .page-index .page--up:focus, .page-index .page--down:focus {
        background-color: var(--btn-icon-hover);
    }
</style>