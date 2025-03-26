import axios from "axios";

const API_URL = "https://localhost:7217/api/form";

export const submitForm = (formData) => axios.post(API_URL, formData);
export const getSubmissions = () => axios.get(API_URL);
