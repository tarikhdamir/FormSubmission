import { createRouter, createWebHistory } from "vue-router";
import Form from "../components/Form.vue";
import SubmissionsList from "../components/SubmissionsList.vue";

const routes = [
    { path: "/", component: Form },
    { path: "/submissions", component: SubmissionsList }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
