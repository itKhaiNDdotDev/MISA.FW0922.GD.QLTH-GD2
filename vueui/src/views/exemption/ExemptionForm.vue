<template>
    <div class="m-popup-wrapper">
        <div class="popup__form exemption-form">
            <div class="form__header">
                Thêm học sinh được miễn giảm
            </div>
            <div class="form__control">
                combo
            </div>
            <div class="form__table">
                <table>
                    Table
                </table>
            </div>
            <div class="form__footer">
                <div class="m-button text-button btn-light">Đóng</div>
                <div class="m-button text-button btn-green">Lưu</div>
            </div>
            <div class="m-icon icon-24 icon-close"></div>
        </div>
    </div>
</template>
<script>
export default {
    name: "ExemptionForm"
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

    }

    .form__control {

    }

    .form__table {

    }

    .form__footer {
        display: flex;
    }

    .popup__form .icon-close {
        position: absolute;
        top: 8px;
        right: 8px;
    }
</style>