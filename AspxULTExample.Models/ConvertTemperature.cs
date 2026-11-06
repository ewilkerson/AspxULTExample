
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;

    namespace AspxULTExample.Models
    {
    public class ConvertTemperature: BaseObject
    {
    private double temperature;

    [Required(ErrorMessage = "This Temperature is required.")]
    [DisplayName("Temperature")]
    [Range(-459.67, 932.00, ErrorMessage = "The temperature must be from -459.67 to 932.00 degrees Celsius, degree Fahrenheit or degrees Kelvin!")]
    [DisplayFormat(DataFormatString = "{0:f}")]
    public double Temperature
    {
    get { return temperature; }
    set { temperature = value; }
    }

    private EnumTemperatureUnit temperatureUnitEnum;

    [DisplayName("Temperature Unit Enum")]
    public EnumTemperatureUnit TemperatureUnitEnum
    {
    get { return temperatureUnitEnum; }
    set { temperatureUnitEnum = value; }
    }

    private string results;

    [DisplayName("Results")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 0)]
    public string Results
    {
    get { return results; }
    set { results = value; }
    }

    private string errorMsg = "The temperature must be from {0} to {1} degrees {2}!";

    public ConvertTemperature()
    {
    results = string.Empty;
    }

    public void FahrenheitKelvinTemperature()
    {
    double minValue = -273.15;
    double maxValue = 500;
    if (temperature >= minValue && temperature <= maxValue)
    {
    double fahrenheit = (temperature * 9 / 5) + 32;
    double kelvin = (temperature + 273.15);
    string msg = temperature + " Celsius = " + fahrenheit + " Fahrenheit or " + kelvin + " Kelvin";
    results = msg;
    }
    else
    {
    ErrID = 1;
    ErrText = string.Format(errorMsg, minValue, maxValue, "Celsius");
    }
    }

    public void CelsiusKelvinTemperature()
    {
    double minValue = -459.67;
    double maxValue = 932;
    if (temperature >= minValue && temperature <= maxValue)
    {
    double celsius = (temperature - 32) * 5 / 9;
    double kelvin = (temperature + 459.67) * 5 / 9;
    string msg = temperature + " Fahrenheit = " + celsius + " Celsius or " + kelvin + " Kelvin";
    results = msg;
    }
    else
    {
    ErrID = 1;
    ErrText = string.Format(errorMsg, minValue, maxValue, "Fahrenheit");
    }
    }

    public void CelsiusFahrenheitTemperature()
    {
    double minValue = 0;
    double maxValue = 773.15;
    if (temperature >= minValue && temperature <= maxValue)
    {
    double celsius = (temperature - 273.15);
    double fahrenheit = (temperature * 9 / 5) - 459.67;
    string msg = temperature + " Kelvin = " + celsius + " Celsius or " + fahrenheit + " Fahrenheit";
    results = msg;
    }
    else
    {
    ErrID = 1;
    ErrText = string.Format(errorMsg, minValue, maxValue, "Kelvin");
    }
    }

    }

    }
  