using Application.Commons;

namespace WebApi.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(
        this Result<T> result,
        ControllerBase controller)
    {
        return result.Type switch
        {
            ResultType.Success =>
                controller.Ok(new
                {
                    data = result.Data,
                    message = result.Message
                }),

            ResultType.NotFound =>
                controller.NotFound(new { error = result.Message }),

            ResultType.ValidationError =>
                controller.BadRequest(new { error = result.Message }),

            ResultType.BusinessError =>
                controller.UnprocessableEntity(new { error = result.Message }),

            ResultType.SystemError =>
                controller.StatusCode(500, new { error = result.Message }),

            _ =>
                controller.StatusCode(500)
        };
    }
}
