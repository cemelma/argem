using IkcUbys.BIP.Mvc.BusinessIntelligence.Builder;
using IkcUbys.BIP.Mvc.BusinessIntelligence.Models;
using IkcUbys.BIP.Mvc.BusinessIntelligence.Models.DynamicTable;
using IkcUbys.BIP.Mvc.BusinessIntelligence.Models.PageModels.Indicators;
using IkcUbys.BIP.Mvc.BusinessIntelligence.Utilities;
using IkcUbys.BIP.Mvc.BusinessIntelligence.Utilities.Enums;
using IkcUbys.BIP.Mvc.UI;
using IkcUbys.BIP.Shared.Data.CriterisObjects;
using IkcUbys.BIP.Shared.Data.DataTransferObjects;
using IkcUbys.BIP.Shared.ServiceContracts.BIManagement;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace IkcUbys.BIP.Mvc.BusinessIntelligence.Controllers
{
    public class IndicatorController : BusinessIntelligenceControllerBase
    {
        #region StudentIndicators

        public ActionResult StudentIndicators()
        {
            ViewBag.StudentIndidacatorsDropDownMenu = new SelectList(GetStudentIndicatorsDropDownMenu(), "Key", "Value");
            return View();
        }

        public PartialViewResult ShowStudentIndicators(string drpStudentIndicator)
        {
            try
            {
                IBIManagementService BIPService = BIPControllerBase.GetServiceProxy<IBIManagementService>();
                int indicatorId = Convert.ToInt32(drpStudentIndicator);
                int?[] degreIds;
                int?[] statusIds;
                
                List<DynamicHtmlTable> resultTable = new List<DynamicHtmlTable>();
                DimAcademicProgramCO academicProgramSearchCriteria = new DimAcademicProgramCO();
                DimAcademicProgramDTO[] academicProgramsArray = null;
                switch (indicatorId)
                {
                    case 1:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Onlisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 1).Value, null, true);
                        break;
                    case 2:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x=>(int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 2).Value, null, true);
                        break;
                    case 3:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 3).Value, null, true);
                        break;
                    case 4:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.SaglikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 4).Value, null, true);
                        break;
                    case 5:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 5).Value, null, true);
                        break;
                    case 6:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 6).Value, null, true);
                        break;
                    case 7:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 7).Value, null, true);
                        break;
                    case 8:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = DefaultStatusIds();
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.SaglikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 8).Value, null, true);
                        break;
                    case 9:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.YuksekLisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 9).Value, null, true);
                        break;
                    case 10:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 10).Value, null, true);
                        break;
                    case 11:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 11).Value, null, true);
                        break;
                    case 12:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 12).Value, null, true);
                        break;
                    case 13:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 13).Value, null, true);
                        break;
                    case 14:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Onlisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 14).Value, null, true);
                        break;
                    case 15:    //?????? BAKILACAK
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Onlisans };
                        statusIds = DefaultStatusIds();
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 15).Value, (int?)EnumCountryTypes.Turkiye, true);
                        break;
                    case 16:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora };
                        statusIds = new int?[] { (int)EnumStudentStatus.Mezun };
                        resultTable = IndicatorBuilder.GetStudentIndicators(degreIds, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 16).Value, null, false);
                        break;
                    case 17:
                        statusIds = new int?[] { (int)EnumStudentStatus.Mezun };
                        resultTable = IndicatorBuilder.GetStudentIndicators(null, null, statusIds, GetStudentIndicatorsDropDownMenu().SingleOrDefault(x => x.Key == 17).Value, null, false);
                        break;
                    default: break;

                }

                PartialTableModel model = new PartialTableModel();
                model.DynamicTable = resultTable;
                model.Header = GetStudentIndicatorsDropDownMenu().Where(x => x.Key == indicatorId).FirstOrDefault().Value;

                return PartialView("../Partial/_dynamictable", model);
            }
            catch (Exception ex)
            {
                return PartialView("../Partial/_dynamictable", null);
            }

        }


        #endregion StudentIndicators

        #region OfficerIndicators

        public ActionResult OfficerIndicators()
        {
            ViewBag.OfficerIndidacatorsDropDownMenu = new SelectList(GetOfficersIndicatorsDropDownMenu(), "Key", "Value");
            return View();
        }

        public PartialViewResult ShowOfficerIndicators(string drpOfficerIndicator)
        {
            try
            {
                IBIManagementService BIPService = BIPControllerBase.GetServiceProxy<IBIManagementService>();
                int indicatorId = Convert.ToInt32(drpOfficerIndicator);
                List<DynamicHtmlTable> resultTable = new List<DynamicHtmlTable>();
                
                List<int> unitList = new List<int>();
                int?[] unvanTypeIds;
                DimAcademicProgramCO academicProgramSearchCriteria = new DimAcademicProgramCO();
                DimAcademicProgramDTO[] academicProgramsArray = null;
                switch (indicatorId)
                {
                    case 1:
                        int?[] unitTypes = new int?[] { (int)EnumUnitTypes.MeslekYuksekOkulu };
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", unitTypes, null, null);
                        break;
                    case 2:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri };
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 3:  //?? .............bakılacak..............
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.ArastirmaGorevlisi };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 4:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 5:  //?? .............bakılacak..............
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.ArastirmaGorevlisi };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler };
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);

                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 6:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.SaglikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 7:  //?? .............bakılacak..............
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.ArastirmaGorevlisi };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.SaglikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, academicProgramsArray.Select(x => (int?)x.FacultyId).ToArray(), unvanTypeIds);
                        break;
                    case 8:  //?? .............bakılacak..............
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, null, unvanTypeIds);
                        break;
                    case 9:  //?? .............bakılacak..............
                        resultTable = IndicatorBuilder.GetOfficerIndicators("AKADEMİK", null, null, null);
                        break;
                    case 10:
                        resultTable = IndicatorBuilder.GetOfficerIndicators("İDARİ", null, null, null);
                        break;
                    default: break;

                }

                PartialTableModel model = new PartialTableModel();
                model.DynamicTable = resultTable;
                model.Header = GetOfficersIndicatorsDropDownMenu().Where(x => x.Key == indicatorId).FirstOrDefault().Value;

                return PartialView("../Partial/_dynamictable", model);
            }
            catch (Exception ex)
            {
                return PartialView("../Partial/_dynamictable", null);
            }

        }

        #endregion OfficerIndicators


        #region PhysicalAreasIndicators
        
        public ActionResult PhysicalAreasIndicators()
        {
            DynamicTable model = IndicatorBuilder.PhysicalAreasIndicators();
            return View(model);
        }

        public ActionResult PhysicalAreasRatios()
        {
            DynamicTable model = IndicatorBuilder.PhysicalAreasRatios();
            //ViewBag.PhysicalAreasIndidacatorsDropDownMenu = new SelectList(GetPhysicalAreasIndicatorsDropDownMenu(), "Key", "Value");
            return View(model);
        }
        
        #endregion PhysicalAreasIndicators


        #region StudentRatios

        public ActionResult StudentsRatios()
        {
            ViewBag.StudentRatiosDropDownMenu = new SelectList(GetStudentRatiosDropDownMenu(), "Key", "Value");
            return View();
        }

        public PartialViewResult ShowStudentRatios(string drpStudentRatios)
        {
            try
            {
                IBIManagementService BIPService = BIPControllerBase.GetServiceProxy<IBIManagementService>();
                DimAcademicProgramCO academicProgramSearchCriteria = new DimAcademicProgramCO();
                DimAcademicProgramDTO[] academicProgramsArray = null;
                IndicatorTableModel indicatorModel = new IndicatorTableModel();
                int indicatorId = Convert.ToInt32(drpStudentRatios);
                List<DynamicHtmlTable> resultTable = new List<DynamicHtmlTable>();
                //ConstantGroupedUnitsForLicence groupedUnitsForLicence = new ConstantGroupedUnitsForLicence();
                List<int> unitList = new List<int>();
                int?[] unvanTypeIds;
                int?[] degreIds;
                int?[] degreIds2;
                int?[] statusIds;
                switch (indicatorId)
                {
                    case 1:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        unvanTypeIds = new int?[0];
                        //int?[] unitTypes = new int?[] { (int)EnumUnitTypes.MeslekYuksekOkulu };
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x=>x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 2:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.BeseriSosyalBilimler};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x => x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 3:  
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                         academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        unvanTypeIds = new int?[0];
                        //int?[] unitTypes = new int?[] { (int)EnumUnitTypes.MeslekYuksekOkulu };
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x => x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 4:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x => x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 5:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora};
                        statusIds = new int?[] { (int)EnumStudentStatus.Mezun };
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, null, null, statusIds, null, null);
                        break;
                    case 6:  
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora};
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, null, null, statusIds, null, null);
                        break;
                    case 7:  
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        degreIds2 = new int?[] { (int)EnumEducationQualificationDegree.Lisans};
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, degreIds2, statusIds,null);
                        break;
                    case 8:  
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                        degreIds2 = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.Onlisans, (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, degreIds2, statusIds,null);
                        break;
                    case 9:  
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.Onlisans, (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, unitList, null, statusIds, null, null);
                        break;
                    case 10: 
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Onlisans};
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, unitList, null, statusIds, null, null);
                        break;
                    case 11:  
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                         academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.SaglikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        unvanTypeIds = new int?[0];
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x => x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 12:
                        unvanTypeIds = new int?[] { (int)EnumKadroUnvanTypes.Profesor, (int)EnumKadroUnvanTypes.Docent, (int)EnumKadroUnvanTypes.YardimciDocent };
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Lisans, (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans };
                         academicProgramSearchCriteria.AcademicUnitTypeIds = new int[] { (int)EAcademicUnitTypeId.DogaMuhendislikBilimleri};
                        academicProgramsArray = BIPService.SearchAcademicPrograms(academicProgramSearchCriteria);
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, academicProgramsArray.Select(x => x.FacultyId).ToList(), unvanTypeIds, statusIds, null, null);
                        break;
                    case 13:
                        degreIds = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.Onlisans, (int)EnumEducationQualificationDegree.Lisans };
                        degreIds2 = new int?[] { (int)EnumEducationQualificationDegree.Doktora, (int)EnumEducationQualificationDegree.YuksekLisans, (int)EnumEducationQualificationDegree.TezsizYuksekLisans, (int)EnumEducationQualificationDegree.Onlisans, (int)EnumEducationQualificationDegree.Lisans };
                        statusIds = DefaultStatusIds();
                        indicatorModel = IndicatorBuilder.GetStudentRatios(degreIds, degreIds2, statusIds, (int)EnumCountryTypes.Turkiye);
                        break;
                    //case 14:
                    //    resultTable = IndicatorBuilder.GetOfficerIndicators("İDARİ", null, null, null);
                    //    break;
                    default: break;

                }

                StudentRatiosModel model = new StudentRatiosModel();
                model.IndicatorTable = indicatorModel;
                model.Header = GetStudentRatiosDropDownMenu().Where(x => x.Key == indicatorId).FirstOrDefault().Value;
                return PartialView("../Partial/_indicatorTable", model);
            }
            catch (Exception ex)
            {
                return PartialView("../Partial/_indicatorTable", null);
            }

        }

        public Dictionary<int, string> GetStudentRatiosDropDownMenu()
        {
            Dictionary<int, string> studentRatiosDropDownMenu = new Dictionary<int, string>();
            studentRatiosDropDownMenu.Add(1, "Beşeri ve Sosyal Bilimler Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Elemanı Sayısı");
            studentRatiosDropDownMenu.Add(2, "Beşeri ve Sosyal Bilimler Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Üyesi Sayısı");
            studentRatiosDropDownMenu.Add(3, "Doğa ve Mühendislik Bilimleri Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Elemanı Sayısı");
            studentRatiosDropDownMenu.Add(4, "Doğa ve Mühendislik Bilimleri Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Üyesi Sayısı");
            studentRatiosDropDownMenu.Add(5, "Doktora Mezun Sayısı / Öğretim Üyesi Sayısı");
            studentRatiosDropDownMenu.Add(6, "Doktora Programındaki Öğrenci Sayısı / Öğretim Üyesi Sayısı");
            studentRatiosDropDownMenu.Add(7, "Lisansüstü Programlardaki Öğrenci Sayısı / Lisans Programlardaki Öğrenci Sayısı");
            studentRatiosDropDownMenu.Add(8, "Lisansüstü Programlardaki Öğrenci Sayısı / Toplam Öğrenci Sayısı");
            studentRatiosDropDownMenu.Add(9, "Öğrenci Sayısı / Öğretim Elemanı Sayısı");
            studentRatiosDropDownMenu.Add(10, "Önlisans Programlarındaki Öğrenci Sayısı / Öğretim Elemanı Sayısı");
            studentRatiosDropDownMenu.Add(11, "Sağlık Bilimleri Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Elemanı Sayısı");
            studentRatiosDropDownMenu.Add(12, "Sağlık Bilimleri Lisans ve Lisansüstü Programlarındaki Öğrenci Sayısı / Öğretim Üyesi Sayısı");
            studentRatiosDropDownMenu.Add(13, "Yabancı Uyruklu Öğrenci Sayısı / Toplam Öğrenci Sayısı");
            //studentRatiosDropDownMenu.Add(14, "Yabancı Uyruklu Öğretim Elemanı Sayısı / Toplam Öğretim Elemanı Sayısı");
            return studentRatiosDropDownMenu;
        }

        #endregion StudentRatios


        public FileResult DownloadFile()
        {
            string filename = Server.MapPath("/etc/deneme.doc");
            string contentType = "application/word";
            return File(filename, contentType, "deneme.doc");
        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult SaveFile(FormCollection collection)
        {
            Random rnd = new Random();
            int fileRandomName = rnd.Next(100000);

            string headerText = collection["headerText"];
            string tableString = collection["tableHtml"];
            string chartHtml = collection["chartHtml"];
            string imagePath = "";
            if (!string.IsNullOrEmpty(tableString))
            {

                StringBuilder htmlFileString = new StringBuilder();
                htmlFileString.AppendLine("<html>");
                htmlFileString.AppendLine("<head>");
                htmlFileString.AppendLine("</head>");
                htmlFileString.AppendLine("<body>");
                htmlFileString.AppendLine(tableString);
                htmlFileString.AppendLine("</body>");
                htmlFileString.AppendLine("</table>");

                using (FileStream fs = new FileStream(Server.MapPath("/etc/" + fileRandomName + ".html"), FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(htmlFileString);
                    }
                }

            }

            if (!string.IsNullOrEmpty(chartHtml))
            {
                imagePath = Server.MapPath("/etc/" + fileRandomName + ".png");
                using (FileStream fs = new FileStream(imagePath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(chartHtml);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }
            }


            Microsoft.Office.Interop.Word.Application word = null;
            Document doc = null;
            object missing = System.Reflection.Missing.Value;
            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
                object oMissing = System.Reflection.Missing.Value;
                word.Visible = true;

                doc = word.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                doc.Activate();

                if (!string.IsNullOrEmpty(tableString))
                {

                    var bookMark = doc.Words.First.Bookmarks.Add("entry");
                    bookMark.Range.InsertFile(Server.MapPath("/etc/" + fileRandomName + ".html"));
                }

                if (!string.IsNullOrEmpty(chartHtml))
                {
                    Paragraph para = doc.Content.Paragraphs.Add(ref missing);
                    para.Range.InsertParagraphAfter();
                    Range rngPic = para.Range;
                    doc.InlineShapes.AddPicture(imagePath, ref missing, true, rngPic);
                }

                doc.SaveAs2(Server.MapPath("/etc/" + fileRandomName + ".doc"));
                doc.Close();
                word.Quit();

                if(System.IO.File.Exists(Server.MapPath("/etc/" + fileRandomName + ".html")))
                    System.IO.File.Delete(Server.MapPath("/etc/" + fileRandomName + ".html"));

                if(System.IO.File.Exists(Server.MapPath("/etc/" + fileRandomName + ".png")))
                    System.IO.File.Delete(Server.MapPath("/etc/" + fileRandomName + ".png"));

                string filename = Server.MapPath("/etc/" + fileRandomName + ".doc");
                string contentType = "application/word";
                string downloadFileName = headerText + ".doc";
                return File(filename, contentType, downloadFileName);

            }
            catch (Exception ex)
            {
                doc.Close();
                word.Quit();
            }




            return null;
        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult SaveTableAsDocFile(FormCollection collection)
        {
            Random rnd = new Random();
            int fileRandomName = rnd.Next(100000);

            string headerText = collection["headerText"];
            string tableString = collection["tableHtml"];
            string imagePath = "";
            if (!string.IsNullOrEmpty(tableString))
            {

                StringBuilder htmlFileString = new StringBuilder();
                htmlFileString.AppendLine("<html>");
                htmlFileString.AppendLine("<head>");
                htmlFileString.AppendLine("</head>");
                htmlFileString.AppendLine("<body style='width:100%;'>");
                htmlFileString.AppendLine("<p><h4>"+headerText+"</h4></p>");
                htmlFileString.AppendLine(tableString);
                htmlFileString.AppendLine("</body>");
                htmlFileString.AppendLine("</table>");

                using (FileStream fs = new FileStream(Server.MapPath("/etc/" + fileRandomName + ".html"), FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(htmlFileString);
                    }
                }

            }



            Microsoft.Office.Interop.Word.Application word = null;
            Document doc = null;
            object missing = System.Reflection.Missing.Value;
            try
            {
                word = new Microsoft.Office.Interop.Word.Application();
                object oMissing = System.Reflection.Missing.Value;
                word.Visible = true;

                doc = word.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                doc.Activate();

                if (!string.IsNullOrEmpty(tableString))
                {

                    var bookMark = doc.Words.First.Bookmarks.Add("entry");
                    bookMark.Range.InsertFile(Server.MapPath("/etc/" + fileRandomName + ".html"));
                }


                doc.SaveAs2(Server.MapPath("/etc/" + fileRandomName + ".doc"));
                doc.Close();
                word.Quit();

                if (System.IO.File.Exists(Server.MapPath("/etc/" + fileRandomName + ".html")))
                    System.IO.File.Delete(Server.MapPath("/etc/" + fileRandomName + ".html"));

                string filename = Server.MapPath("/etc/" + fileRandomName + ".doc");
                string contentType = "application/word";
                string downloadFileName = headerText + ".doc";
                return File(filename, contentType, downloadFileName);

            }
            catch (Exception ex)
            {
                doc.Close();
                word.Quit();
            }




            return null;
        }


        //[HttpPost]
        //[ValidateInput(false)]
        //public FileResult SaveFile(FormCollection collection)
        //{
        //    Random rnd = new Random();
        //    int fileRandomName = rnd.Next(100000);

        //    string headerText = collection["headerText"];
        //    string tableString = collection["tableHtml"];
        //    StringBuilder htmlFileString = new StringBuilder();
        //    htmlFileString.AppendLine("<html>");
        //    htmlFileString.AppendLine("<head>");
        //    htmlFileString.AppendLine("</head>");
        //    htmlFileString.AppendLine("<body>");
        //    htmlFileString.AppendLine(tableString);
        //    htmlFileString.AppendLine("</body>");
        //    htmlFileString.AppendLine("</table>");

        //    using (FileStream fs = new FileStream(Server.MapPath("/etc/"+fileRandomName+".html"), FileMode.Create))
        //    {
        //        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
        //        {
        //            w.WriteLine(htmlFileString);
        //        }
        //    } 
            
        //    string chartHtml = collection["chartHtml"];


        //    string path = Server.MapPath("/etc/"+fileRandomName+".png");

        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        using (BinaryWriter bw = new BinaryWriter(fs))
        //        {
        //            byte[] data = Convert.FromBase64String(chartHtml);
        //            bw.Write(data);
        //            bw.Close();
        //        }
        //        fs.Close();
        //    }

        //    Microsoft.Office.Interop.Word.Application word=null;
        //    Document doc=null;
        //    object missing = System.Reflection.Missing.Value;


        //    try
        //    {
        //        word = new Microsoft.Office.Interop.Word.Application();
        //        object oMissing = System.Reflection.Missing.Value;
        //        word.Visible = true;
                
        //        doc = word.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        //        doc.Activate();

        //        var bookMark = doc.Words.First.Bookmarks.Add("entry");
        //        bookMark.Range.InsertFile( Server.MapPath("/etc/"+fileRandomName+".html"));

        //        Paragraph para = doc.Content.Paragraphs.Add(ref missing);
        //        para.Range.InsertParagraphAfter();
        //        Range rngPic = para.Range;
        //        doc.InlineShapes.AddPicture(path, ref missing, true, rngPic);
                
        //        doc.SaveAs2(Server.MapPath("/etc/" + fileRandomName + ".doc"));
        //        doc.Close();
        //        word.Quit();

        //        System.IO.File.Delete(Server.MapPath("/etc/" + fileRandomName + ".html"));
        //        System.IO.File.Delete(Server.MapPath("/etc/" + fileRandomName + ".png"));

        //        string filename = Server.MapPath("/etc/" + fileRandomName + ".doc");
        //        string contentType = "application/word";
        //        string downloadFileName = headerText + ".doc";
        //        return File(filename, contentType, downloadFileName);

        //    }
        //    catch(Exception ex)
        //    {
        //        doc.Close();
        //        word.Quit();
        //    }


       

        //    return null;
        //}

        



        #region Methods

        #region Students
        public Dictionary<int, string> GetStudentIndicatorsDropDownMenu()
            {
                Dictionary<int, string> studentIndicatorsDropDownMenu = new Dictionary<int, string>();
                studentIndicatorsDropDownMenu.Add(1, "Önlisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(2, "Doğa ve Mühendislik Bilimleri Programları Toplam Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(3, "Beşeri ve Sosyal Bilimler Programları Toplam Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(4, "Sağlık Bilimleri Programları Toplam Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(5, "Toplam Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(6, "Doğa ve Mühendislik Bilimleri Programları Toplam Lisansüstü Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(7, "Beşeri ve Sosyal Bilimler Programları Toplam Lisansüstü Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(8, "Sağlık Bilimleri Programları Toplam Lisansüstü Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(9, "Tezli Yüksek Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(10, "Tezsiz Yüksek Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(11, "Toplam Yüksek Lisans Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(12, "Doktora Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(13, "Toplam Lisansüstü Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(14, "Toplam Öğrenci Sayısı");
                studentIndicatorsDropDownMenu.Add(15, "Yabancı Uyruklu Öğrenci sayısı");
                studentIndicatorsDropDownMenu.Add(16, "Doktora Mezun Sayısı");
                studentIndicatorsDropDownMenu.Add(17, "Toplam Mezun Sayısı");
                return studentIndicatorsDropDownMenu;
            }
        int?[] DefaultStatusIds()
        {
            return new int?[] { (int)EnumStudentStatus.Aktif, (int)EnumStudentStatus.KayitDondurma };
        }
        #endregion Students

        #region Officers
            public Dictionary<int, string> GetOfficersIndicatorsDropDownMenu()
            {
                Dictionary<int, string> officerIndicatorsDropDownMenu = new Dictionary<int, string>();
                officerIndicatorsDropDownMenu.Add(1, "Önlisans Programlarındaki Öğretim Elemanı Sayısı");
                officerIndicatorsDropDownMenu.Add(2, "Doğa ve Mühendislik Bilimleri Lisans ve Lisansüstü Programlardaki Toplam Öğretim Üyesi Sayısı");
                officerIndicatorsDropDownMenu.Add(3, "Doğa ve Mühendislik Bilimleri Lisans ve Lisansüstü Programlardaki Toplam Araştırma Görevlisi Sayısı");
                officerIndicatorsDropDownMenu.Add(4, "Beşeri ve Sosyal Bilimler Lisans ve Lisansüstü Programlardaki Toplam Öğretim Üyesi Sayısı");
                officerIndicatorsDropDownMenu.Add(5, "Beşeri ve Sosyal Bilimler Lisans ve Lisansüstü Programlardaki Toplam Araştırma Görevlisi Sayısı");
                officerIndicatorsDropDownMenu.Add(6, "Sağlık Bilimleri Lisans ve Lisansüstü Programlardaki Toplam Öğretim Üyesi Sayısı");
                officerIndicatorsDropDownMenu.Add(7, "Sağlık Bilimleri Lisans ve Lisansüstü Programlardaki Toplam Araştırma Görevlisi Sayısı");
                officerIndicatorsDropDownMenu.Add(8, "Toplam Öğretim Üyesi Sayısı");
                officerIndicatorsDropDownMenu.Add(9, "Toplam Öğretim Elemanı Sayısı");
                //officerIndicatorsDropDownMenu.Add(11, "Yabancı Uyruklu Öğretim Elemanı Sayısı");
                //officerIndicatorsDropDownMenu.Add(12, "40/b ile Gelen Öğretim Elemanı Sayısı");
                officerIndicatorsDropDownMenu.Add(10, "İdari Personel Sayısı");
                return officerIndicatorsDropDownMenu;
            }
        #endregion Officers

        #region PhysicalAreas
            public Dictionary<int, string> GetPhysicalAreasIndicatorsDropDownMenu()
            {
                Dictionary<int, string> physicalAreasIndicatorDropDownMenu = new Dictionary<int, string>();
                physicalAreasIndicatorDropDownMenu.Add(1, "Araştırma Alanı Miktarı / Toplam Öğretim Elemanı Sayısı");
                physicalAreasIndicatorDropDownMenu.Add(2, "Eğitim + Araştırma Alanı Miktarı / Toplam Öğrenci Sayısı");
                physicalAreasIndicatorDropDownMenu.Add(3, "Beşeri ve Sosyal Bilimler Programları Toplam Öğrenci Sayısı");
                physicalAreasIndicatorDropDownMenu.Add(4, "Sağlık Bilimleri Programları Toplam Lisans Öğrenci Sayısı");
                physicalAreasIndicatorDropDownMenu.Add(5, "Toplam Lisans Öğrenci Sayısı");
                return physicalAreasIndicatorDropDownMenu;
            }
        #endregion PhysicalAreas

    

        #endregion Methods
    }
}