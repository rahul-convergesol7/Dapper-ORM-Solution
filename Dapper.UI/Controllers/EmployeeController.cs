using CoreApiResponse;
using Dapper.Domain;
using Dapper.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dapper.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            this._employee = employee;
        }


        #region Add the employee
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] employeeMaster employeeMaster)
        {
            bool isSaved = await _employee.AddEmployee(employeeMaster);
            try
            {
                if (isSaved)
                {
                    return CustomResult("Employee Added SuccessFully",HttpStatusCode.OK);
                }
                return CustomResult("User Can't Inserting",HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Get All Employee List
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var listOfEmployee = await _employee.GetAllEmployee();
            try
            {
                if(listOfEmployee != null) { 
                return CustomResult("successfull Get All Employee", listOfEmployee, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("Something Went Wrong!", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Get employee By Id
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var getSingle = await _employee.GetEmployeeById(id);
            try
            {
                if (getSingle != null)
                {
                    return CustomResult(getSingle, HttpStatusCode.OK);
                }
                return CustomResult("Something Went Wrong", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Update employee  
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(employeeMaster employeeMaster)
        {
            bool isSaved = await _employee.UpdateEmployee(employeeMaster);
            try
            {
                if (isSaved)
                {
                    return CustomResult("update Employee Data SuccessFully", employeeMaster, HttpStatusCode.OK);
                }
                return CustomResult("Employee Can't Update", isSaved, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Delete emplooyee
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool isSaved = await _employee.DeleteEmployee(id);
            try
            {
                if (isSaved)
                {
                    return CustomResult("Delete Employee Data SuccessFully", HttpStatusCode.OK);
                }
                return CustomResult("Employee Can't Delete", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        #endregion

    }
}
