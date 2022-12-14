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
                    <thead>
                        <tr>
                            <th style="max-width: 200px;">Khoản thu</th>
                            <th style="max-width: 270px;">Diện miễn giảm</th>
                            <th style="width: 130px; max-width: 130px;">Mức miễn giảm</th>
                            <th style="width: 150px; max-width: 150px;">Thời gian miễn giảm</th>
                            <th style="width: 100px; max-width: 100px;">Từ tháng</th>
                            <th style="width: 100px; max-width: 100px;">Đến tháng</th>
                            <th style="width: 36px; max-width: 40px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="cell__text--left" style="max-width: 200px;">Sữa học đường</td>
                            <td class="cell__text--left" style="max-width: 270px;">Con hạ sỹ quan, binh sĩ, chiến sĩ</td>
                            <td class="cell__text--right" style="width: 130px; max-width: 130px;">100,00%</td>
                            <td style="width: 150px; max-width: 150px;">Cả năm</td>
                            <td class="cell__text--left" style="width: 100px; max-width: 270px;">08/2021</td>
                            <td class="cell__text--left" style="width: 100px; max-width: 270px;">05/2022</td>
                            <td class="m-icon icon-24 icon-remove"></td>
                        </tr>
                        <tr>
                            <td class="cell__text--left" style="max-width: 200px;">Tiền ăn bán trú</td>
                            <td class="cell__text--left" style="max-width: 270px;">Bị tàn tật, khuyết tật thuộc diện hộ nghèo hoặc hộ cận nghèo</td>
                            <td class="cell__text--right" style="width: 130px; max-width: 130px;">100,00%</td>
                            <td class="cell__text--left" style="width: 150px; max-width: 150px;">Cả năm</td>
                            <td class="cell__text--left" style="width: 100px; max-width: 270px;">08/2021</td>
                            <td class="cell__text--left" style="width: 100px; max-width: 270px;">05/2022</td>
                            <td class="m-icon icon-24 icon-remove"></td>
                        </tr>
                        <tr class="table__tr--add">
                            <td colspan="7">
                                <div class="m-icon icon-plus-blue text--link">Thêm miễn giảm</div>
                            </td>          
                        </tr>
                    </tbody>
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
        position: relative;
    }
    .form__table table {
        position: absolute;
        top: -1px;
        left: -1px;
        width: calc(100% + 2px);
    }
    .form__table .table__tr--add {
        border-top: 2px solid var(--border);
    }
    .form__table .table__tr--add td div {
        background-position: 0px center;
        padding-left: 20px;
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