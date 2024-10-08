using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class QuotationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Village { get; set; }

        public string Taluka { get; set; }
        public string District { get; set; }

        public string SurveyNo {  get; set; }

        public string LandArea { get; set; }

        public string MobileNo {  get; set; }

        public string ApplicationNo {  get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateOnly? App_Date {  get; set; }

        public string Email { get; set; }

        public string App_mobileNo {  get; set; }

        public string ProcessFees { get; set; }

        public string Pro_Refe_no {  get; set; }

        public DateOnly? Pro_Date {  get; set; }

        public string? MeasurementNo {  get; set; }

        public string? Measur_Refe_No {  get; set; }

        public DateOnly? Measur_Date {  get; set; }

        public string? MeasurOrNot {  get; set; }

        public string? Opinion { get; set; }
        public string? CircleOfficer { get; set; }
        public string? Mamlatdar {  get; set; }
        public string? Other {  get; set; }
        public DateOnly? Con_letter_Date {  get; set; }
        public string Con_Amount {  get; set; }

        public string Con_Refe_No { get; set; }

        public DateOnly? Con_Date {  get; set; }

        public string Con_Amount_Dtl {  get; set; }

        public DateOnly? Amount_Dtl_Date {  get; set; }

        public string layout { get; set; }

        public string uncultivat_appli { get; set; }
        public string Measurment_appli { get; set; }
        public string ConversionTax {  get; set; }

        public string lay_out { get; set; }
        public string? Document { get; set; }
        public int StatusId { get; set; } = 1;
    }
}
