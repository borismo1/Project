﻿namespace BackEnd.Model
{
    public class ServiceResponce<T>
    {

        public T Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
