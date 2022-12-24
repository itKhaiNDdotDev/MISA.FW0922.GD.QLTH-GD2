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
                <button class="page--up m-icon icon-up-next" @click="onClickPageUp"></button>
                <button class="page--down m-icon icon-down-prev" @click="onClickPageDown"></button>
                <input type="text" class="m-input" v-model="pageIndex" @keyup.enter="setPageIndex">
            </div>
            <span>&nbsp; {{pagingText.onTotalPage.toLowerCase()}}&nbsp;</span>
            <span class="paging__number">{{Math.ceil(totalRecord/pageSize)}}</span>
            <span>&nbsp;{{pagingText.Page.toLowerCase()}}</span>
        </div>
    </div>
</template>

<script>
import ExemptionResources from "./../../utils/resources/exemption"
import { PAGE_SIZE } from "./../../utils/constants/api"
// import MInput from "./../../components/base/MInput.vue";

export default {
    name: "ExemptionPaging",
    components: {
        // MInput
    },

    props: ["totalRecord"],
    data() {
        return {
            pagingText: ExemptionResources.Paging,
            pageIndex: 1,
            pageSize: PAGE_SIZE
        }
    },

    methods: {


        /**
         * Gọi đến Component cha yêu cầu set giá trị số trang hiện tại tương ứng từ ô input pageIndex
         * Author: KhaiND (24/12/2022)
         */
        setPageIndex() { //Đang dùng cho sự kiện onKeyUp phím Enter tại ô input nhập pageIndex
            try {
                if(this.pageIndex < 1) {
                    this.pageIndex = 1;
                    // Nên xử lý báo input không hợp lệ
                }
                if(this.pageIndex > Math.ceil(this.totalRecord/PAGE_SIZE)) {
                    this.pageIndex = Math.ceil(this.totalRecord/PAGE_SIZE);
                    // Nên xử lý báo lỗi input không hợp lệ
                }    
                this.$emit("setPageIndex", this.pageIndex);
            }
            catch(error) {
                console.log(error);
                //this.$emit('searchEmployee', "", 1);
                //Gửi STATE báo lỗi về cha
            }
        },

        /**
         * Sự kiện khi người dùng bấm vào icon pageUp ở ô input phân trang tương ứng thì chuyển về trang sau
         * Author: KhaiND (24/12/2022)
         */
        onClickPageUp() {
            try {
                if(this.pageIndex < Math.ceil(this.totalRecord/PAGE_SIZE)) {
                    this.pageIndex += 1;
                    this.$emit("setPageIndex", this.pageIndex);
                }
            }
            catch(error) {
                console.log(error);
                this.pageIndex = 1;
                //Gửi STATE lỗi về cha
            }
        },

        /**
         * Sự kiện khi người dùng bấm vào icon pageDown ở ô input phân trang tương ứng thì chuyển về trang trước
         * Author: KhaiND (24/12/2022)
         */
        onClickPageDown() {
            try {
                if(this.pageIndex > 1) {
                    this.pageIndex -= 1;
                    this.$emit("setPageIndex", this.pageIndex);
                }
            }
            catch(error) {
                console.log(error);
                this.pageIndex = 1;
                //Gửi STATE lỗi về cha
            }
        },
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
    .page-index button:focus ~ input {
        border-color: var(--border-active);
    }
    .page-index input {
        width: 100%;
        padding-right: 24px;
    }
    .page-index .page--up, .page-index .page--down {
        position: absolute;
        right: 1px;
        width: 20px;
        height: 15px;
        cursor: pointer;
        border-radius: 4px;
        outline: none;
        border: none;
        background-color: transparent;
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