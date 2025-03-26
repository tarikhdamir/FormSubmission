<template>
    <div class="form-container">
        <h2>Contact Form</h2>
        <form @submit.prevent="submitForm">
            <!-- Name -->
            <div class="form-group">
                <label for="name">Full Name</label>
                <input type="text" id="name" v-model="form.name" required />
                <span v-if="errors.name" class="error">{{ errors.name }}</span>
            </div>

            <!-- Country -->
            <div class="form-group">
                <label for="country">Country</label>
                <select id="country" v-model="form.country" required>
                    <option value="">Select a country</option>
                    <option value="USA">USA</option>
                    <option value="UK">UK</option>
                    <option value="Germany">Germany</option>
                </select>
                <span v-if="errors.country" class="error">{{ errors.country }}</span>
            </div>

            <!-- Date of Birth -->
            <div class="form-group">
                <label for="dob">Date of Birth</label>
                <input type="date" id="dob" v-model="form.dob" required />
                <span v-if="errors.dob" class="error">{{ errors.dob }}</span>
            </div>

            <!-- Gender -->
            <div class="form-group">
                <label>Gender</label>
                <div class="radio-group">
                    <label class="radio-inline">
                        <input type="radio" value="Male" v-model="form.gender" /> Male
                    </label>
                    <label class="radio-inline">
                        <input type="radio" value="Female" v-model="form.gender" /> Female
                    </label>
                    <label class="radio-inline">
                        <input type="radio" value="Other" v-model="form.gender" /> Other
                    </label>
                </div>
                <span v-if="errors.gender" class="error">{{ errors.gender }}</span>
            </div>

            <!-- Terms Agreement (Checkbox) -->
            <div class="form-group">
                <div class="checkbox-group">
                    <input type="checkbox" id="terms" v-model="form.terms" />
                    <label for="terms">I agree to the Terms and Conditions</label>
                </div>
                <span v-if="errors.terms" class="error">{{ errors.terms }}</span>
            </div>

            <button type="submit">Submit</button>
        </form>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                form: {
                    name: "",
                    country: "",
                    dob: "",
                    gender: "",
                    terms: false
                },
                errors: {}
            };
        },
        methods: {
            validateForm() {
                this.errors = {};

                if (!this.form.name) this.errors.name = "Name is required.";
                if (!this.form.country) this.errors.country = "Please select a country.";
                if (!this.form.dob) this.errors.dob = "Date of Birth is required.";
                if (!this.form.gender) this.errors.gender = "Please select a gender.";
                if (!this.form.terms) this.errors.terms = "You must agree to the terms.";

                return Object.keys(this.errors).length === 0;
            },
            async submitForm() {
                if (!this.validateForm()) return;

                try {
                    const response = await axios.post("https://localhost:7217/api/form", this.form);
                    alert("Form submitted successfully!");
                    console.log(response.data);
                    this.form = {
                        name: "",
                        country: "",
                        dob: "",
                        gender: "",
                        terms: false
                    };
                } catch (error) {
                    console.error("Error submitting form", error);
                    alert("Failed to submit form.");
                }
            }
        }
    };
</script>

<style scoped>
    .form-container {
        max-width: 400px;
        margin: auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
        background-color: #f9f9f9;
    }

    .form-group {
        margin-bottom: 15px;
        justify-items: left;
    }

    input, select {
        width: 100%;
        padding: 8px;
        margin-top: 5px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    .radio-group {
        display: flex;
        gap: 15px;
        margin-top: 5px;
    }

    .radio-inline {
        display: flex;
        align-items: center;
        gap: 5px;
    }

    .checkbox-group {
        display: flex;
        align-items: center;
        gap: 8px;
        white-space: nowrap;
    }

    .error {
        color: red;
        font-size: 12px;
        display: block;
        margin-top: 5px;
    }

    button {
        width: 100%;
        padding: 10px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

        button:hover {
            background-color: #0056b3;
        }
</style>
