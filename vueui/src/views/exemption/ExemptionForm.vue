<template>
    <div class="m-popup-wrapper">
        <div class="popup__form exemption-form">
            <div class="form__header">
                Thêm học sinh được miễn giảm
            </div>
            <div class="form__control">
                <MCombobox label="Họ và tên" isRequired="true" :errorState="errorInputSate"/>
            </div>
            <div class="form__table">
                <table>
                    Table
                </table>
            </div>
            <div class="form__footer">
                <div class="m-button text-button btn-light" @click="onClose">Đóng</div>
                <div class="m-button text-button btn-green">Lưu</div>
            </div>
            <div class="m-icon icon-24 icon-close" @click="onClose"></div>
        </div>
    </div>
</template>

<script>
import MCombobox from "./../../components/base/MCombobox.vue";

export default {
    name: "ExemptionForm",
    components: {
        MCombobox
    },

    data() {
        return {
            isShow: true,
            errorInputSate: {
                isError: true,
                message: "Có lỗi rồi"
            }
        }
    },

    methods: {
        /**
         * Sự kiên khi bấm vào yêu cầu đóng thì gọi đến Component cha để yêu cầu hủy DOM của Form
         * Author: KhaiND (13/12/2022)
         */
        onClose() {
            this.$emit("onClose");
        }
    },
}
</script>

<style>
    .popup__form {
        width: 1024px;
        height: 512px;
        display: flex;
        flex-direction: column;
    }

    .form__header {
        font-size: 16px;
        font-family: OpenSansSemiBold;
        padding: 16px;
    }

    .form__control {
        padding: 0px 16px;
        height: 64px;
        width: fit-content;
    }

    .form__table {
        flex: 1;
        border: 1px solid var(--border);
        margin: 0px 16px;
    }

    .form__footer {
        height: 56px;
        display: flex;
        align-items: center;
        justify-content: right;
        padding-right: 16px;
    }

    .popup__form .icon-close {
        position: absolute;
        top: 8px;
        right: 8px;
    }
</style>