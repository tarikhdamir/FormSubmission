<template>
    <div class="submissions-container">
        <h2>Submitted Forms</h2>

        <!-- 🔍 Search Bar -->
        <input v-model="searchQuery"
               placeholder="Search submissions..."
               class="search-bar" />

        <!-- 📋 Submissions Table -->
        <table class="submissions-table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Submitted At</th>
                    <th>Form Data</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="submission in filteredSubmissions" :key="submission.id">
                    <td>{{ submission.id }}</td>
                    <td>{{ formatDate(submission.submittedAt) }}</td>
                    <td>
                        <pre>{{ submission.formData }}</pre>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                submissions: [],
                searchQuery: ""
            };
        },
        computed: {
            // 🔎 Filter submissions based on search
            filteredSubmissions() {
                return this.submissions.filter(submission =>
                    JSON.stringify(submission.formData)
                        .toLowerCase()
                        .includes(this.searchQuery.toLowerCase())
                );
            }
        },
        methods: {
            async fetchSubmissions() {
                try {
                    const response = await axios.get("https://localhost:7217/api/form");
                    this.submissions = response.data;
                } catch (error) {
                    console.error("Error fetching submissions", error);
                }
            },
            formatDate(dateString) {
                return new Date(dateString).toLocaleString();
            }
        },
        mounted() {
            this.fetchSubmissions();
        }
    };
</script>

<style scoped>
    .submissions-container {
        padding: 20px;
    }

    h2 {
        text-align: center;
    }

    .search-bar {
        display: block;
        margin: 10px auto;
        padding: 8px;
        width: 50%;
        font-size: 16px;
    }

    .submissions-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

        .submissions-table th, .submissions-table td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .submissions-table th {
            background-color: #f4f4f4;
        }
</style>
