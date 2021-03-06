﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VKMessages.Core.Models;

namespace VKMessages.Core
{
    public class ResponseDeserializer
    {
        private readonly Converters converters;

        public ResponseDeserializer()
        {
            converters = new Converters();
        }

        public TModel Deserialize<TModel>(string response) where TModel : ResponseModel, new()
        {
            var data = JObject.Parse(response).GetValue("response"); ;
            var model = new TModel();

            FillModel(model, data.Last());

            return model;
        }

        public List<TModel> DeserializeMany<TModel>(string response) where TModel : ResponseModel, new()
        {
            var data = JObject.Parse(response).GetValue("response");;

            var values = data.Value<JArray>().Skip(1);

            var models = new List<TModel>();

            foreach (var value in values)
            {
                var model = new TModel();

                FillModel(model, value);

                models.Add(model);
            }

            return models;
        }

        private void FillModel(ResponseModel model, JToken value)
        {
            var properties = model.GetType().GetProperties()
                  .Where(p => Attribute.IsDefined(p, typeof(ResponsePropertyAttribute)));

            foreach (var property in properties)
            {
                var propertyAttribute = (ResponsePropertyAttribute)property
                    .GetCustomAttributes(typeof(ResponsePropertyAttribute), true).First();

                var val = value.SelectToken(propertyAttribute.Name).ToString();

                var convertedValue = converters.ConverterDictionary[property.PropertyType](val);

                property.SetValue(model, convertedValue);
            }
        }
    }
}