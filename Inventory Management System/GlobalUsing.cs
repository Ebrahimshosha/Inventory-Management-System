global using Inventory_Management_System;

global using FoodApp.Api.VerticalSlicing.Features.Common;
global using FoodApp.Api.VerticalSlicing.Features.Common.Helper;
global using FoodApp.Api.VerticalSlicing.Data.Context;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Interface;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Repository;
global using FoodApp.Api.VerticalSlicing.Features.Account.Common.Helper;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using System.Diagnostics;
global using System.Text;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using FoodApp.Api.VerticalSlicing.Common;
global using FoodApp.Api.VerticalSlicing.Data.Entities;
global using FoodApp.Api.VerticalSlicing.Features.Account;
global using MediatR;
global using Newtonsoft.Json;
global using RabbitMQ.Client;
global using RabbitMQ.Client.Events;

global using Microsoft.AspNetCore.Mvc;
global using System.Security.Claims;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification;
global using AutoMapper;
global using FoodApp.Api.VerticalSlicing.Features.Account.Login.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount;
global using FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResendVerificationCode;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResendVerificationCode.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword.Commands;

global using Microsoft.VisualBasic;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Cryptography;
global using FoodApp.Api.Extensions;
global using Microsoft.Extensions.Options;
global using FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword.Commands;
global using Inventory_Management_System.VerticalSlicing.Data.Entities;
global using Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct.Commands;

global using Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct.Queries;
global using Inventory_Management_System.VerticalSlicing.Features.Products.ViewProduct.Queries;
global using Inventory_Management_System.VerticalSlicing.Features.Products.AddProduct;
global using Inventory_Management_System.VerticalSlicing.Features.Products.UpdateProduct.Commands;
global using Inventory_Management_System.VerticalSlicing.Data.Repository.Specification.ProductSpec;
global using Inventory_Management_System.VerticalSlicing.Features.Products.ViewProduct;
global using Inventory_Management_System.VerticalSlicing.Features.Products.ListProducts.Comands;
global using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.AddStock.Commands;
global using Microsoft.AspNetCore.Authorization;
global using Inventory_Management_System.VerticalSlicing.Features.InventoryTransactions.TransferStock.Commands;

global using Inventory_Management_System.VerticalSlicing.Data.Context;

global using Inventory_Management_System.VerticalSlicing.Features.Common.Middlewares;
global using Inventory_Management_System.VerticalSlicing.Features.Reporting.LowStockReport.Queries;
global using Inventory_Management_System.VerticalSlicing.Features.Reporting.TransactionHistory.Queries;
