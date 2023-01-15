<template>
  <div class="m-popup-wrapper" @keyup.esc="onClose">
    <div class="popup__form import-form">
        <div class="form__process">
            <div class="form__process--left" :class="{doneStep:isResultStep}">Chon tiep nguon</div>
            <div class="form__process--right" :class="{processingStep:isResultStep}">Xac nhan va nhap khau</div>
        </div>
        <div class="form__modal">
            <div v-if="!isResultStep" class="form__file">
                <span>Chon tep nhap khau</span>
                <div class="file__source">
                    <input class="m-input" type="text" :value="fileName">
                    <div class="file__source--action">
                        <label for="file-input">
                            <div class="icon-button btn-light m-icon icon-file"></div>
                        </label>
                        <input type="file" name="" id="file-input" @change="getfileName" accept=".xls,.xlsx">
                    </div>
                </div>
            </div>
            <div v-if="!isResultStep" class="form__notice icon-toast-info">
                Tệp dữ liệu phải có dạng .xls và dung lượng &#x3C; 2MB. Vui lòng tải tệp đúng định dạng để hệ thống có thể nhận diện thông tin trên tệp.
                <a class="text--link" href="">Tải tệp mẫu</a>
            </div>
            <div v-if="isResultStep" class="import__dashborad">
                <div class="dashboard--total">
                    <div class="dashboard__title">Số bản ghi</div>
                    <div class="dashboard__count">3</div>
                </div>
                <div class="dashboard--valid">
                    <div class="dashboard__title">Hợp lệ</div>
                    <div class="dashboard__count">2</div>
                </div>
                <div class="dashboard--invalid">
                    <div class="dashboard__title">Không hợp lệ</div>
                    <div class="dashboard__count">1</div>
                </div>
            </div>
            <div v-if="isResultStep" class="import__result-file">
                <span class="icon-arrow-download">Bạn có thể tải danh sách bản ghi không hợp lệ để chỉnh sửa và nhập khẩu lại.</span>
                <div class="form__notice">
                    <a class="text--link" href="">Tải tất cả bản ghi</a>
                    <div class="hor-line"></div>
                    <a class="text--link" href="">Tải về bản ghi không hợp lệ</a>          
                </div>
            </div>
        </div>
        <div class="form__footer">
            <div class="m-button text-button btn-light" @click="onClose">{{buttonText.Close}}</div>
            <div v-if="!isResultStep" class="m-button text-button btn-green" @click="onChangeStep(true)">{{buttonText.Save}}</div>
            <div v-if="isResultStep" class="m-button text-button btn-light" @click="onChangeStep(false)">{{buttonText.Back}}</div>
            <div v-if="isResultStep" class="m-button text-button btn-green">{{buttonText.ConfirmImport}}</div>
        </div>
    </div>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";

export default {
    name: "ExemptionImport",

    data() {
        return {
            buttonText: Resources.Button,
            fileName: "",
            isResultStep: false
        }
    },

    methods: {
        getfileName(event) {
            this.fileName = event.target.files;
            console.log(this.fileName);
            console.log(this.fileName[0].name);
            console.log(this.fileName[0].size); // phuc vu validete file size
            this.fileName = this.fileName[0].name;
        },

        onChangeStep(isNext) {
            this.isResultStep = isNext;
        },

        /**
         * Sự kiên khi bấm vào yêu cầu đóng thì gọi đến Component cha để yêu cầu hủy DOM của Form
         * Author: KhaiND (30/12/2022)
         */
        onClose() {
            try {
                this.$emit("onClose");
            }
            catch(error) {
                console.log(error);
                // Gửi STATE báo lỗi về cha
            }
        },
    },
};
</script>

<style>
@import url(../../styles/view/import.css);
</style>